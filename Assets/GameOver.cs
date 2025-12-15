using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; 

public class GameOver : MonoBehaviour
{
    
    //VARIABLE 1: references the GameOverScreen panel made in the hierarchy
    public GameObject gameOverPanel;

    //VARIABLE 2: timer script reference so it can stop when user wins
    public Timer timerScript;

    //VARIABLE 3: win or lose text on game over screen
    public Text gameOverText;

    //VARIABLE 4: what score to win game?
    public int winScore = 100; 




    // Start is called before the first frame update
    void Start()
    {
        //the "Game Over" screen should not be shown on the screen
        //when the game begins so SetActive is set to false to hide it
        gameOverPanel.SetActive(false);
    }


    //this function is called when a fish is caught
    public void FishisCaught()
    {
        //has player reached score 100?
        if (ScoreTracker.score >= winScore)
        {
            //100 pts met, then they won and timer stops
            timerScript.timerStopped();
            //game over screen shows 
            ShowGameOver("You Won!");
        }
    }

    //function called by Timer when time is up
    public void TimeIsUp()
    {
        //player ran out of time, then they lost
        ShowGameOver("Time is Up. You Lost!");
    }


    //shows the game over screen and stops the game. 
    //string parameter to show different sentences
    private void ShowGameOver(string message)
    {
        //text shows if they won/lost
        gameOverText.text = message;
        //show the GameOver screen by setting SetActive(true)
        gameOverPanel.SetActive(true);

        //time.timescale controls the speed of the game
        //0 means it is stopped and 1 is normal
        Time.timeScale = 0f;
    }


    //this function restarts the game for the play again button
    public void RestartGame()
    {
        //set game speed back to normal time
        Time.timeScale = 1f;

        //reloads the game to the first scene again with 0
        SceneManager.LoadScene(0);
    }
        

  
}
