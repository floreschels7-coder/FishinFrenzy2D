using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    //VARIABLE 1: this is referencing the pause menu (that says PAUSED)
    public GameObject pauseMenuPanel;
    //VARIABLE 2: keeps track of whether the game is paused or not
    //true = is paused and false = game is playing
    private bool isPaused = false;


    // Start is called before the first frame update
    void Start()
    {
        //When the game begins, this makes sure the pause panel object
        //is hidden 
        pauseMenuPanel.SetActive(false);
    }

    //function is called when player clicks pause or resume button
    public void PauseOrResume()
    {
        //the ! (not) flips the value
        //if isPaused was false, it becomes true
        //if isPaused was true, it is then false
        isPaused = !isPaused;

        //First check: after the flip, are we paused or not?
        if (isPaused)
        {
            //if we are currently paused, then unpause (false)
            ResumeGame();
            isPaused = false;
        }
        else
        {
            //if we are currently not paused, then pause
            PauseGame();
            isPaused = true;
        }
    }

    // stops the game and shows the pause menu
    void PauseGame()
    {
        //Time.timeScale determines how fast time in the game
        //0 = paused, 1 = normal speed
        Time.timeScale = 0f; //aka paused

        //Now time to show the pause menu by turning it on
        //SetActive(true) menas show the object
        pauseMenuPanel.SetActive(true);
    }

    //function resumes the game and turns off the pause menu
    void ResumeGame()
    {
        //set time back to normal speed 
        Time.timeScale = 1f;

        //hide the pause menu by marking it as false
        pauseMenuPanel.SetActive(false);
    }
}
