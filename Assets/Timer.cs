using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{

    //amt of time given to players
    public float time = 20f; 

    //shows timer on screen
    public Text timerText;

    //time running out or no?
    public bool timerRunning = false;

    //game over script
    public GameOver gameOverScript;


    // Start is called before the first frame update
    void Start()
    {
        //begin timer when game starts
        timerRunning = true;
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
