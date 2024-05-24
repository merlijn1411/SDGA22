using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;

public class MissionUpdater : MonoBehaviour
{
 
    public Gamecontroller gameController;
    public addScore addScoreController;

    public int requiredCorrectedPipes;
    public int requiredScore;

    public HoldInteraction[] holdInteractions;

    public GameObject Taskbook;
    public GameObject Checkmark1;
    public GameObject Checkmark2;

    private bool game1Complete = false;
    private bool game2Complete = false;

    public int requiredInteractions;
    private int completedInteractions = 0;

    public TextMeshProUGUI progressText;


    bool hide = false;
    private bool isMissionComplete = false;

    public GameObject winScreen;



    private void Start()
    {
        Checkmark1.SetActive(false);
        Checkmark2.SetActive(false);

        winScreen.SetActive(false);

        InVisibleCursor();

        foreach (HoldInteraction interaction in holdInteractions)
        {
            interaction.OnInteractionComplete += HandleInteractionComplete;
        }
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

        if (game1Complete && game2Complete && isMissionComplete)
        {
            Taskbook.SetActive(false);
            ShowWinScreen();
        }

        if (Input.GetKey(KeyCode.Tab))
        {
            hide = !hide;
            if (hide)
            {
                Taskbook.SetActive(false);
                Thread.Sleep(100);
            }
            else
            {
                if (!hide)
                {
                    Taskbook.SetActive(true);
                    Thread.Sleep(100);
                }

            }
        }



    }

    //deze twee functie zijn als je de minigames hebt gedaan dat je dan te zien krijgt in het taskboekje dat ze zijn gedaan 
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

    //als je de HandleInteraction hebt gecomplete krijg je te zien dat het is gelukt 
    private void HandleInteractionComplete()
    {
        if (isMissionComplete)
            return;

        completedInteractions++;

        if (completedInteractions >= requiredInteractions && !isMissionComplete)
        {
            isMissionComplete = true;
            Debug.Log("Mission Complete!");
        }

        UpdateProgressText();
    }
    private void UpdateProgressText()
    {
        progressText.text = $"{completedInteractions}/{requiredInteractions}"; //dit is voor de HoldInteraction script text
    }

    //als je alle tasks hebt gedaan heb je het spel gewonnen en krijg je het win scherm 
    private void ShowWinScreen()
    {
        Time.timeScale = 0f;
        winScreen.SetActive(true);

        VisibleCursor();
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

