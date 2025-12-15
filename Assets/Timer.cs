using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
        //count down if timer is running
        if (timerRunning)
        {
            //check time left
            if(time > 0)
            {
                //subtract time and time.deltatime is the
                //  amt of time passed since the last frame
                time -= Time.deltaTime;

                //update text on screen 
                //Mathf rounds to nearest whole number
                timerText.text = "Time: " + Mathf.Round(time).ToString();
            }
            else
            {
                //time ran out so stop timer from going negative
                time = 0;
                timerRunning = false; 
                timerText.text = "Time: 0";

                //GameOver script knows that time is up 
                gameOverScript.TimeIsUp();

            }
        }
    }

    //functions stop timer when player wins
    public void timerStopped()
    {
        timerRunning = false;
    }
}
