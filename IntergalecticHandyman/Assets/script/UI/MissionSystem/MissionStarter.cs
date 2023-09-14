using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using System.Threading;
using static UnityEngine.Timeline.AnimationPlayableAsset;

public class MissionStarter : MonoBehaviour
{
    public Gamecontroller gameController; 
    public addScore addScoreController;

    public int requiredCorrectedPipes;
    public int requiredScore;

    public HoldInteraction[] holdInteractions;

    public GameObject Taskbook;
    public GameObject Checkmark1;
    public GameObject Checkmark2;  

    public int requiredInteractions;

    public TextMeshProUGUI progressText;

    public GameObject winScreen;



    private void Start()
    {
        Checkmark1.SetActive(false);
        Checkmark2.SetActive(false);

        winScreen.SetActive(false);

        InVisibleCursor();

    }


    public void VisibleCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public void InVisibleCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}