using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlastRadius : MonoBehaviour
{
    // Start is called before the first frame update
    List<Rigidbody> inBlast;
    void Start()
    {
        inBlast = new List<Rigidbody>();
    }


    private void OnTriggerStay(Collider other)
    {
        if (other.tag != "Player" && other.attachedRigidbody != null)
        {
            if (!inBlast.Contains(other.attachedRigidbody))
            {
                inBlast.Add(other.attachedRigidbody);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag != "Player" && other.attachedRigidbody != null)
        {
            if (inBlast.Contains(other.attachedRigidbody))
            {
                inBlast.Remove(other.attachedRigidbody);
            }
        }
    }

    public void ApplyExplosionForce(Vector3 blastOrigin, float radius, float upwardmod, float force, ForceMode mode)
    {
        foreach (Rigidbody rb in inBlast)
        {
            
            Vector3 forcedir = rb.position - blastOrigin; // direction vector from origin of explosion
            forcedir.y += upwardmod * force;
            rb.AddForce(forcedir * force, mode);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
