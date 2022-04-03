using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour
{
    public static gameManager Instance;

    public bool countingDown;

    public AudioClip[] cowSounds;

    public int score;

    public gameMenu gameMenu;

    public bool gettingReady = false, buildingPower = false;

    public slingshot slingshot;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(this);
    }

    // Start is called before the first frame update
    void Start()
    {
        gameMenu.gameStartTimer.startTimer(5, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public AudioClip playCowSound()
    {

        int x = Random.Range(0, 14);
        return cowSounds[x];

    }

    public void startBuildingPower()
    {
        print("building power");
        slingshot.puller.pullingString = true;
        gameMenu.gameStartMenu.gameObject.SetActive(false);
        gameMenu.buildPowerMenu.gameObject.SetActive(true);
        gameMenu.buildPowerTimer.startTimer(5, 1);
    }

 
}
