using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class MissionSystem : MonoBehaviour
{
    public Gamecontroller gameController; 
    public addScore addScoreController;

    public int requiredCorrectedPipes;
    public int requiredScore;


    

    public Text game1StatusText; 
    public Text game2StatusText; 

    private bool game1Complete = false;
    private bool game2Complete = false;

    private void Update()
    {
        if (!game1Complete && gameController.GetCorrectedPipes() >= requiredCorrectedPipes) // is gelinkt aan de pipe GameController script
        {
            // Mission condition met
            game1Complete = true;
            Debug.Log("Game 1 completed!");
            CompleteGame1();
        }

        if (!game2Complete && addScoreController.score >= requiredScore) // is gelinkt aan de addscore script
        {
            CompleteGame2();
        }
    }

    private void CompleteGame1()
    {
        game1Complete = true;
        Debug.Log("Game 1 completed!");
        game1StatusText.text = "Game 1 Complete";
    }

    private void CompleteGame2()
    {
        game2Complete = true;
        Debug.Log("Game 2 completed!");
        game2StatusText.text = "Game 2 Complete";
    }
}