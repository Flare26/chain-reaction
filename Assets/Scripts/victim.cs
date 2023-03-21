using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class victim : MonoBehaviour
{
    public Rigidbody[] rig;
    public bool inFlight = false, inFreefall = false;
    public Rigidbody prb;
    public gameManager gm;
    private float timeMovingSlow = 0;
    private Vector3 lastPos;
    private Vector3 transformDeltas;
    private float transformSpd;
    private Transform startingParent;
    private Vector3[] startingRigPosVals;
    private Quaternion[] startingRigRotVals;

    private void Awake()
    {
        startingParent = transform.parent;
        rig = GetComponentsInChildren<Rigidbody>();
        startingRigPosVals = new Vector3[rig.Length];
        startingRigRotVals = new Quaternion[rig.Length];
        for (int i = 0; i < rig.Length; i++)
        {
            startingRigPosVals[i] = rig[i].transform.position;
            startingRigRotVals[i] = rig[i].transform.rotation;
        }
        
        //prb = transform.parent.GetComponentInParent<Rigidbody>();
        disableRagdoll();
        lastPos = transform.position;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //print("rig[0] speed = " + rig[0].velocity.magnitude);
        float playerVel = rig[0].velocity.magnitude;
        if (inFlight)
        {
            if (Input.GetButtonDown("Jump"))
            {
                dismount();
            }  

        }

        // check for if the player has stopped moving quickly

        if((inFlight == true || inFreefall == true ) && playerVel < 0.1f)
        {
            timeMovingSlow += Time.deltaTime;
        }

        // check if player is not moving fast enough for too long

        if (timeMovingSlow > 4f && (inFlight == true || inFreefall == true))
        {
            // Next round, not moving fast enough for too long.
            print("Resetting round...");
            disableRagdoll();
            gm.NextRound();
            transform.parent = startingParent;
            for (int i = 0; i < 0; i++)
            {
                rig[i].position = startingRigPosVals[i];
                rig[i].rotation = startingRigRotVals[i];
            }
            // reset time on floor until the player launches again
            timeMovingSlow = 0;
            inFlight = false;
            inFreefall = false;
            Scene s = SceneManager.GetActiveScene();
            SceneManager.LoadScene(s.name);
        }

    }

    

    public void activateRagdoll()
    {
        //print("activated " + rig.Length + "bones");
        for (int i = 0; i < rig.Length; i++)
        {
           rig[i].gameObject.SetActive(true);
            rig[i].isKinematic = false;
        }

    }

    public void disableRagdoll()
    {
        //print("disabled " + rig.Length + "bones");
        foreach (Rigidbody rb in rig)
        {
            rb.isKinematic = true;
            rb.gameObject.SetActive(false);
        }
    }

    public void dismount()
    {

            Debug.Log("PARENT TO VICTIM IS " + transform.parent.name);
            Vector3 pv = prb.velocity;

            Vector3 impulseLocation = new Vector3(transform.parent.transform.position.x, transform.parent.transform.position.y, transform.parent.transform.position.z);
            transform.parent = null;
            activateRagdoll();
            print("launching " + rig.Length + "bones");
            foreach (Rigidbody bone in rig)
            {
                // transfer momentum from parent before cutting ties
                bone.velocity = pv;
            }
            rig[0].AddExplosionForce(250, impulseLocation, 10, 10, ForceMode.Impulse);

            inFlight = false;
            inFreefall = true;
        gm.gameMenu.dismountText.gameObject.SetActive(false);
    }
}
