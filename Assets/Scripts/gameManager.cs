using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour
{
    public static gameManager Instance;

    public bool countingDown;

    public AudioClip[] cowSounds;

    public timer timer;

    public int score;

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

        timer.startTimer(5);
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
}
