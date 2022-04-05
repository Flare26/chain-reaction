using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class gameMenu : MonoBehaviour
{
    public TMP_Text leftArrow, rightArrow;

    public TMP_Text startText, buildText;

    public TMP_Text scoreText, dismountText;

    public GameObject gameStartMenu, buildPowerMenu;
    public timer gameStartTimer, buildPowerTimer;

    public gameManager gm;

    // Start is called before the first frame update
    void Start()
    {
 
    }

    // Update is called once per frame
    void Update()
    {
 
            int x = (int)gameStartTimer.timeRemaining;
            startText.text = x.ToString();

            x = (int)buildPowerTimer.timeRemaining;
            buildText.text = x.ToString();

            scoreText.text = gm.score.ToString();
    }

    public void alternateArrow(bool dir)
    {
        if (dir)
        {
            leftArrow.alpha = 0;
            rightArrow.alpha = 1;
        }
        else
        {
            leftArrow.alpha = 1;
            rightArrow.alpha = 0;
        }
    }

    public void returnToMenu()
    {
        print("returning");
        SceneManager.LoadScene("mainMenu");
    }

}
