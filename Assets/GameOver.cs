using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    
    //VARIABLE 1: references the GameOverScreen panel made in the hierarchy
    public GameObject gameOverPanel;

    //VARIABLE 2:  how many fish need to be caught to end the game?
    public int totalFishCount = 5;

    //VARIABLE 3: Need to determine and track how many fish have been 
    //caught so far. It will start at 0.
    private int fishCaught = 0; 




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
        //Add 1 to the fish counter each time a fish is caught. 
        fishCaught++;
        
        //Check if all the fish have been caught
        if (fishCaught >= totalFishCount)
        {
            //then all fish are caught so show game over screen. 
            ShowGameOver();
        }
    }


    //shows the game over screen and stops the game. 
    private void ShowGameOver()
    {
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
