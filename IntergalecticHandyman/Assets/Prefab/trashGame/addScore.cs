using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class addScore : MonoBehaviour
{
    public int score = 0;
    private showRadius GamecameraScript;

    public GameObject Dot;

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
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            Dot.SetActive(true);
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
}
