using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirbornController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Rigidbody hips;
    [SerializeField] float forceMult;

    [SerializeField] float floorBounding;

    victim v;
    void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;
        v = GetComponent<victim>();
    }


    private void Update()
    {
        if (true)
        {

            if (Input.GetKey(KeyCode.A))
            {
                //Debug.Log("Holding A");
                hips.AddForce(Vector3.forward * forceMult, ForceMode.Acceleration);
            }

            if (Input.GetKey(KeyCode.D))
            {
                //Debug.Log("Holding D");
                hips.AddForce(Vector3.back * forceMult, ForceMode.Acceleration);
            }

            if (Input.GetKey(KeyCode.W))
            {
                //Debug.Log("Holding W");
                Vector3 diag = Vector3.Normalize(Vector3.right + Vector3.up / 2);
                hips.AddForce( diag * forceMult, ForceMode.Acceleration);
            }

            if (Input.GetKey(KeyCode.S))
            {
                //Debug.Log("Holding S");
                hips.AddForce(Vector3.left * forceMult, ForceMode.Acceleration);
            }
        }
    }
}
