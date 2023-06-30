using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimerManager : MonoBehaviour
{
    private Gamecontroller gamecontroller;
    public TMP_Text timerText;
    public int minutes = 2;
    public int seconds = 30;
    public TMP_Text GameoverScreen;
    public GameObject ButtonTry;
    public GameObject buttonQuit;


    private void Start()
    {
        StartCoroutine(StartCountdown()); 
        GameoverScreen.gameObject.SetActive(false);
        timerText.gameObject.SetActive(true);
        ButtonTry.SetActive(false);
        buttonQuit.SetActive(false);
    }

    private void Update()
    {
        
    }

    private IEnumerator StartCountdown()
    {
        while (minutes >= 0 && seconds >= 0)
        {
            timerText.text = minutes.ToString("00") + ":" + seconds.ToString("00");

            yield return new WaitForSeconds(1);

            if (seconds == 0)
            {
                if (minutes == 0)
                {
                    // Countdown has finished
                    Debug.Log("Game over ");
                    GameoverScreen.gameObject.SetActive(true);
                    timerText.gameObject.SetActive(false);
                    ButtonTry.SetActive(true);
                    buttonQuit.SetActive(true);
                    Time.timeScale = 0f;
                    break;
                }
                else
                {
                    minutes--;
                    seconds = 59;
                }
            }
            else
            {
                seconds--;
            }
        }
    }
}