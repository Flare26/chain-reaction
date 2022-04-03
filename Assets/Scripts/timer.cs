using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timer : MonoBehaviour
{
    public bool isRunning;
    public float timeRemaining;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isRunning)
        {
            timeRemaining -= Time.deltaTime;
        }
    }

    public void startTimer(float time)
    {
        timeRemaining = time;
        isRunning = true;
    }

    public void stopTimer()
    {
        isRunning = false;
    }
}
