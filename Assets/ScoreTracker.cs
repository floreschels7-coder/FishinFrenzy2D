using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; //textMeshPro text

public class ScoreTracker : MonoBehaviour
{
    //VARIBALE 1: this is like the "scoreboard" that be keeping track of the score
    //creates a "slot" for the number to show up in
    public static ScoreTracker instance;

    //VARIABLE 2:This is the text that will be connected to the text that is shown on the screen. 
    //which is the score. 
    public TMP_Text scoreText;

    //VARIABLE 3: this number will be the actual current score
    private int score = 0;



    // Start is called before the first frame update
    void Start()
    {
        //'this' is the ScoreTracker that can be 
        // accessed and called referring to the ScoreTracker instance
        instance = this;

        //show the score
        UpdateScoreText();

    }

    
    //we want it to be integers
    public void AddScore(int points)
    {
        //take the current score and add the points
        score += points;

        //time to update the score on screen after the points are added
        UpdateScoreText();
    }


    void UpdateScoreText()
    {
        scoreText.text = "Score: " + score;
    }
}
