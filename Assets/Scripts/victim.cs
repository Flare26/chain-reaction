using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class victim : MonoBehaviour
{
    public Rigidbody[] rig;
    public bool inFlight = false, inFreefall = false; 

    private void Awake()
    {
        rig = GetComponentsInChildren<Rigidbody>();
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
        activateRagdoll();
        inFlight = false;
        inFreefall = true;
    }
}
