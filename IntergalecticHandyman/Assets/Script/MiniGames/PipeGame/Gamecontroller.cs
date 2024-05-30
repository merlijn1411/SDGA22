using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gamecontroller : MonoBehaviour
{
    public GameObject pipesHolder;
    public GameObject[] pipes;

    [SerializeField]
    int totalpipes = 0;
    [SerializeField]
    int correctedPipes = 0;

    private InteractionRadius GamecameraScript;

    internal bool WinPipeGame = false;

    public GameObject Dot;

    public GameObject TaskBook;
    

    // Start is called before the first frame update
    void Start()
    {
        //GamecameraScript = transform.parent.Find("canvasGameKnop").GetComponent<InteractionRadius>();
        
        totalpipes= pipesHolder.transform.childCount;

        pipes = new GameObject[totalpipes];

        for (int i = 0; i < pipes.Length; i++)
        {
            pipes[i] = pipesHolder.transform.GetChild(i).gameObject;
        }
    }

    public void correctMove()
    {
        correctedPipes += 1;

        if(correctedPipes == totalpipes)
        {
            Debug.Log("Je hebt Gewonnen");
            // GamecameraScript.cam1.SetActive(true);
            // GamecameraScript.cam2.SetActive(false);
            InVisibleCursor();
            Dot.SetActive(true);
            WinPipeGame = true;
            TaskBook.SetActive(true);
        }
    }
    public int GetCorrectedPipes()
    {
        return correctedPipes; //voor de MissionSystem script
    }

    public void wrongMove()
    {
        correctedPipes-= 1;
        
    }
    public void InVisibleCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

}
