using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slingshotPuller : MonoBehaviour
{
    public gameManager gm;
    public float incrementSize, distancePulled, launchPower;
    public Transform drawFrom, drawTo;
    public slingshotSling slingshotSling;
    public slingshot slingshot;

    public Transform crate;
    public gameMenu gameMenu;

    bool firstInput = false, nextInput = false;
    public bool pullingString = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (pullingString)
        {
            //L=0,R=1
            //check first imput to determine to determine next input
            if (!firstInput)
            {
                if (Input.GetButtonDown("L"))
                {
                    firstInput = true;
                    nextInput = true;
                    pullSling();

                }
                else if (Input.GetButtonDown("R"))
                {
                    firstInput = true;
                    nextInput = false;
                    pullSling();
                }
            }
            else
            {
                if (!nextInput && Input.GetButtonDown("L"))
                {
                    nextInput = true;
                    distancePulled += incrementSize;
                    pullSling();
                }
                if (nextInput && Input.GetButtonDown("R"))
                {
                    nextInput = false;
                    distancePulled += incrementSize;
                    pullSling();
                }
            }
        }
        else
        {
            //return sling to home
            if (distancePulled > 0)
            {
                crate.transform.position = Vector3.Lerp(drawFrom.position, drawTo.position, distancePulled / 100);
                distancePulled -= Time.deltaTime * launchPower;
            }
        }

        //if (Input.GetButtonDown("Jump") && slingshot.victim.inFlight == false && slingshot.victim.inFreefall == false)
        //{
         //   releaseSling();
        //}

    }

    public void pullSling()
    {
        distancePulled += incrementSize;
        launchPower += 10;
        crate.transform.position = Vector3.Lerp(drawFrom.position, drawTo.position, distancePulled / 100);
        gameMenu.alternateArrow(nextInput);
    }

    public void releaseSling()
    {
        pullingString = false;
        slingshot.yeet();
    }
}
