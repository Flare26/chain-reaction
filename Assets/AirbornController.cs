using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirbornController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Rigidbody hips;
    [SerializeField] float forceMult;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            Debug.Log("Holding A");
            hips.AddForce(Vector3.forward * forceMult, ForceMode.Acceleration);
        }

        if (Input.GetKey(KeyCode.D))
        {
            Debug.Log("Holding D");
            hips.AddForce(Vector3.back * forceMult, ForceMode.Acceleration);
        }

        if (Input.GetKey(KeyCode.W))
        {
            Debug.Log("Holding W");
            hips.AddForce(Vector3.right * forceMult, ForceMode.Acceleration);
        }

        if (Input.GetKey(KeyCode.S))
        {
            Debug.Log("Holding S");
            hips.AddForce(Vector3.left * forceMult, ForceMode.Acceleration);
        }
    }
}
