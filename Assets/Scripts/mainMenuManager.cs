using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenuManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startGame(int level)
    {
        if (level == 0)
        {
            SceneManager.LoadScene("gameScene");
        }
        else
        {
            SceneManager.LoadScene("Mountain!");
        }
        
    }
}
