using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseMenu : MonoBehaviour
{
    public static bool GameisPaused = false;
    public GameObject pauseMenuUI;
    void Start() 
    {
        
        Resume();
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (GameisPaused) 
            { 
                Resume();
            }
            else
            {
                Pause();
            }
        }
        
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameisPaused = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }


    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameisPaused = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
        Debug.Log("Loading menu...");
    }

}
