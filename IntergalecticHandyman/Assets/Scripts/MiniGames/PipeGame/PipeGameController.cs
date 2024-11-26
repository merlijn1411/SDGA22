using UnityEngine;
using UnityEngine.Events;

public class PipeGameController : MonoBehaviour
{
    [SerializeField] private GameObject pipesHolder;
    private GameObject[] pipes;

    private int totalPipes = 0;
    private int correctedPipes = 0;

    public UnityEvent onCompleteTask;
    
    
    private void Start()
    {
        totalPipes = pipesHolder.transform.childCount;
        pipes = new GameObject[totalPipes];

        InitializePipes();
    }

    private void InitializePipes()
    {
        var pl = pipes.Length;
        for (var i = 0; i < pl; i++)
        {
            pipes[i] = pipesHolder.transform.GetChild(i).gameObject;
        }
    }

    public void CorrectMove()
    {
        correctedPipes += 1;

        if (correctedPipes != totalPipes) return;
            onCompleteTask.Invoke();
    }

    public void wrongMove()
    {
        correctedPipes-= 1;
        
    }

}
