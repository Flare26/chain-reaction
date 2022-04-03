using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slingshot : MonoBehaviour
{
    public slingshotPuller puller;
    public slingshotSling sling;
    
    public bool holdingObject;
    public Vector3 yeetDirection;

    public Transform holdPosition;

    public GameObject crate;
    public victim victim;

    public float yeetMultiplier;

    void Awake()
    {
        crate.GetComponent<Rigidbody>().isKinematic = true;
    }
    // Start is called before the first frame update
    void Start()
    {
        yeetDirection = new Vector3(1, 0.25f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        //if (puller.pullingString)
        //{
            //objectToBeYeeted.transform.position = holdPosition.position;
        //}
    
    }

    public void yeet()
    {
        crate.transform.parent = null;
        crate.GetComponent<Rigidbody>().isKinematic = false;
        victim.inFlight = true;
        crate.GetComponent<Rigidbody>().AddForce(yeetDirection * puller.launchPower * yeetMultiplier * Time.deltaTime, ForceMode.Acceleration);
    }
}
