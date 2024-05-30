using UnityEngine;

public class PipeGameController : MonoBehaviour
{
    [SerializeField] private GameObject pipesHolder;
    [SerializeField] private GameObject[] pipes;

    private int totalPipes = 0;
    private int correctedPipes = 0;

    internal bool WinPipeGame = false;
    
    void Start()
    {
        
        totalPipes = pipesHolder.transform.childCount;

        pipes = new GameObject[totalPipes];

        InitializePipes();
    }

    private void InitializePipes()
    {
        var pl = pipes.Length;
        for (int i = 0; i < pl; i++)
        {
            pipes[i] = pipesHolder.transform.GetChild(i).gameObject;
        }
    }

    public void CorrectMove()
    {
        correctedPipes += 1;

        if (correctedPipes != totalPipes) return;
        Debug.Log("Je hebt Gewonnen");
        WinPipeGame = true;
    }
    public int GetCorrectedPipes()
    { 
        return correctedPipes; 
    }

    public void wrongMove()
    {
        correctedPipes-= 1;
        
    }

}
