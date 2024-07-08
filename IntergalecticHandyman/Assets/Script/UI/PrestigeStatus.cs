using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PrestigeStatus : MonoBehaviour
{
    [SerializeField] private TMP_Text text;

    public void Win()
    {
        text.text = $"You Win!";
    }
    public void Loose()
    {
        text.text = $"You Losed!";
    }
    public void LoadGame()
    {
        SceneManager.LoadScene("Game");
    }
    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    
    
}
