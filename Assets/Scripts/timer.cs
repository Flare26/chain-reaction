using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timer : MonoBehaviour
{
    public bool isRunning;
    public float timeRemaining;
    public gameManager gm;
    public int timerPurpose;
    //0=start, 1 = power, 2 = cooldown
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (isRunning && timeRemaining>0)
        {
            timeRemaining -= Time.deltaTime;
        }

        if (timeRemaining <=0)
        {
            switch (timerPurpose)
            {
                case 0:
                    startGameTimerComplete();
                    break;
                case 1:
                    buildPowerTimerComplete();
                    break;
                case 2:
                    cooldownTimerComplete();
                    break;

            }
        }
    }

    public void startTimer(float time, int purpose)
    {
        timerPurpose = purpose;
        timeRemaining = time;
        isRunning = true;
    }

    public void stopTimer()
    {
        isRunning = false;
    }

    public void startGameTimerComplete()
    {
        stopTimer();
        gm.startBuildingPower();
    }

    public void buildPowerTimerComplete()
    {
        stopTimer();
        gm.slingshot.puller.releaseSling();
        gm.gameMenu.buildPowerMenu.gameObject.SetActive(false);
    }

    public void cooldownTimerComplete()
    {
        stopTimer();
    }

}
