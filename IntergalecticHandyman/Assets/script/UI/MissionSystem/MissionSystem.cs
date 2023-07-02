using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEditor.Experimental.GraphView;

public class MissionSystem : MonoBehaviour
{
    public Gamecontroller gameController; 
    public addScore addScoreController;

    public int requiredCorrectedPipes;
    public int requiredScore;

    public GameObject Taskbook;
    public GameObject Checkmark1;
    public GameObject Checkmark2;   

    private bool game1Complete = false;
    private bool game2Complete = false;

    bool hide = false;


    private void Start()
    {
        Checkmark1.SetActive(false);
        Checkmark2.SetActive(false);
    }
    private void Update()
    {
        if (!game1Complete && gameController.GetCorrectedPipes() >= requiredCorrectedPipes) // is gelinkt aan de pipe GameController script
        {
            CompleteGame1();
        }

        if (!game2Complete && addScoreController.score >= requiredScore) // is gelinkt aan de addscore script
        {
            CompleteGame2();
        }

        if (Input.GetKey(KeyCode.Tab))
        {
            hide = !hide;
            if(hide)
            {
                Taskbook.SetActive(false);
            }
            else Taskbook.SetActive(true);
        }
        
    }

    private void CompleteGame1()
    {
        game1Complete = true;
        Debug.Log("Game 1 completed!");
        Checkmark1.SetActive(true);
    }

    private void CompleteGame2()
    {
        game2Complete = true;
        Debug.Log("Game 2 completed!");
        Checkmark2.SetActive(true);
    }
}