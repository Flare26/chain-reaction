using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class victim : MonoBehaviour
{
    public Rigidbody[] rig;
    public bool inFlight = false, inFreefall = false;
    public Rigidbody prb;
    public gameManager gm;

    private void Awake()
    {
        rig = GetComponentsInChildren<Rigidbody>();
        //prb = transform.parent.GetComponentInParent<Rigidbody>();
        disableRagdoll();
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (inFlight)
        {
            if (Input.GetButtonDown("Jump"))
            {
                dismount();
            }  

        }
    }

    public void activateRagdoll()
    {
        print("activated " + rig.Length + "bones");
        for (int i = 0; i < rig.Length; i++)
        {
           rig[i].gameObject.SetActive(true);
            rig[i].isKinematic = false;
        }

    }

    public void disableRagdoll()
    {
        print("disabled " + rig.Length + "bones");
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
