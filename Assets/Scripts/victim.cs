using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class victim : MonoBehaviour
{
    public Rigidbody[] rig;
    public bool inFlight = false, inFreefall = false;
    Rigidbody prb;

    private void Awake()
    {
        rig = GetComponentsInChildren<Rigidbody>();
        prb = transform.parent.GetComponentInParent<Rigidbody>();
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
        foreach (var rb in rig)
        {
            rb.gameObject.SetActive(true);
            rb.isKinematic = false;
        }
    }

    public void disableRagdoll()
    {
        foreach (var rb in rig)
        {
            rb.isKinematic = true;
            rb.gameObject.SetActive(false);
        }
    }

    public void dismount()
    {
        
        foreach(Rigidbody bone in rig)
        {
            // transfer momentum from parent before cutting ties
            //bone.velocity = 

        }

        Vector3 impulseLocation = new Vector3(transform.parent.transform.position.x, transform.parent.transform.position.y, transform.parent.transform.position.z);
        transform.parent = null;
        activateRagdoll();
        rig[0].AddExplosionForce(25000, impulseLocation, 10);
        inFlight = false;
        inFreefall = true;
    }
}
