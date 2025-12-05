using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScreen : MonoBehaviour
{

    //function is called when the start button is clicked
    public void StartGame()
    {
        //loads main game scene index 1
        SceneMangaer.LoadScene(1);
    }
}
