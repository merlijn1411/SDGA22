using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PrestigeStatus : MonoBehaviour
{
    [SerializeField] private TMP_Text Text;
    
    public void Win()
    {
        Text.text = $"You Win!";
        VisibleCursor();
    }
    public void Loose()
    {
        Text.text = $"You Losed!";
        VisibleCursor();
    }
    public void RetryGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        InVisibleCursor();
        Time.timeScale = 1f;
    }
    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
        VisibleCursor();
    }
    
    private void VisibleCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    private void InVisibleCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
