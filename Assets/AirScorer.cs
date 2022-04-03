using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirScorer : MonoBehaviour
{
    gameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.Find("GM").GetComponent<gameManager>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
            gm.score += 1775;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
