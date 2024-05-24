using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class addScore : MonoBehaviour
{
    public int score = 0;
    private showRadius GamecameraScript;

    public GameObject TaskBook;

    public GameObject Dot;

    public GameObject TutorialScreen;

    private void Start()
    {
        GamecameraScript = transform.parent.Find("canvasGameKnop").GetComponent<showRadius>();
    }
    private void Update()
    {
        if (score == 5)
        {
            Debug.Log("je hebt gewonnen");
            GamecameraScript.cam1.SetActive(true);
            GamecameraScript.cam2.SetActive(false);
            InVisibleCursor();
            Dot.SetActive(true);
            TaskBook.SetActive(true);

        }
    }
    private void OnTriggerEnter(Collider other)
    {
        score++;
        
        if (other.tag == "trash")
        {
            Destroy(other.gameObject);  
            

        }
    }
    public void InVisibleCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    public void StartButton()
    {
        TutorialScreen.SetActive(false);
        Time.timeScale = 1f;
    }
}
