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

    private showRadius1 GamecameraScript;

    internal bool WinPipeGame = false;

    // Start is called before the first frame update
    void Start()
    {
        GamecameraScript = transform.parent.Find("canvasGameKnop").GetComponent<showRadius1>();
        
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
            GamecameraScript.cam1.SetActive(true);
            GamecameraScript.cam2.SetActive(false);
            WinPipeGame= true;
        }
    }

    public void wrongMove()
    {
        correctedPipes-= 1;
        
    }
   
}
