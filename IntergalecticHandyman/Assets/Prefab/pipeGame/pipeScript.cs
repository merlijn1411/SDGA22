using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pipeScript : MonoBehaviour
{
    float[] rotations = { 0, 90, 180, 270 };

    public float[] correctRotation;
    [SerializeField]
    bool inPlace = false;

    int PossibleRots = 1;

    Gamecontroller gameManager;

    private void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<Gamecontroller>();
    }

    private void Start()
    {

        
        PossibleRots = correctRotation.Length;
        int rand = Random.Range(0, rotations.Length);
        transform.eulerAngles = new Vector3(0, 0, rotations[rand]);

        if (PossibleRots > 1)
        {
            if (transform.eulerAngles.z == correctRotation[0] || transform.eulerAngles.z == correctRotation[1])
            {
                inPlace = true;
                gameManager.correctMove();
            }
        }
        else
        {
            if (transform.eulerAngles.z == correctRotation[0] )
            { 
                inPlace = true;
                gameManager.correctMove();
            }
        }
        
        
    }

    private void OnMouseDown()
    {
        transform.Rotate(new Vector3(0, 0, 90));

        if (PossibleRots > 1)
        {
            if (transform.eulerAngles.z == correctRotation[0] || transform.eulerAngles.z == correctRotation[1] && inPlace == false)
            {
                inPlace = true;
                gameManager.correctMove();
            }
            else if (inPlace == true)
            {
                inPlace = false;
                gameManager.wrongMove();
            }
        }
        else
        {
            if (transform.eulerAngles.z == correctRotation[0]  && inPlace == false)
            {
                inPlace = true;
                gameManager.correctMove();
            }
            else if (inPlace == true)
            {
                inPlace = false;
                gameManager.wrongMove();
            }
        }
       
    }
}
