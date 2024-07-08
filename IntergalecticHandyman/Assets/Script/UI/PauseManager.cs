using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    [SerializeField] private bool isGamePaused = false;
    public UnityEvent onPaused;
    public UnityEvent onPlay;

    private void Update()
    {
        PauseToggler();
    }

    private void PauseToggler()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            switch (isGamePaused)
            {
                case true:
                    Resume();
                    break;
                case false:
                    Pause();
                    break;
            }
        }
    }

    public void Resume()
    {
        isGamePaused = !isGamePaused;
        onPlay.Invoke();
        Time.timeScale = 1f;
    }
    private void Pause()
    {
        isGamePaused = !isGamePaused;
        onPaused.Invoke();
        Time.timeScale = 0f;
    }
    
    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }

    public void QuitGame()
    {
        Debug.Log("Quitting Game...");
        Application.Quit();
    }
}
