using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slingshot : MonoBehaviour
{
    public slingshotPuller puller;
    public slingshotSling sling;
    public GameObject objectToBeYeeted;
    public bool holdingObject;
    public Vector3 yeetDirection;

    public Transform holdPosition;
    // Start is called before the first frame update
    void Start()
    {
        yeetDirection = new Vector3(1, 0.25f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (puller.pullingString)
        {
            objectToBeYeeted.transform.position = holdPosition.position;
        }
    
    }

    public void yeet()
    {
        objectToBeYeeted.GetComponent<Rigidbody>().AddForce(yeetDirection * puller.launchPower * 10, ForceMode.Acceleration);
    }
}