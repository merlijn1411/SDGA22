using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TimerManager : MonoBehaviour
{
    private Gamecontroller gamecontroller;
    public TMP_Text timerText;
    public int minutes = 2;
    public int seconds = 30;
    public GameObject GameoverScreen;


    private void Start()
    {
        StartCoroutine(StartCountdown()); 
        GameoverScreen.gameObject.SetActive(false);
        timerText.gameObject.SetActive(true);
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
    public void LoadGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Game");
        Debug.Log("Loading menu...");
    }
}
