using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class showRadius : MonoBehaviour
{
    public float radius;
    public TextMeshProUGUI E;
    public Transform player;
    
    public GameObject Dot;

    public GameObject TaskBook;

    public GameObject cam1;
    public GameObject cam2;

    public GameObject TutorialScreen;
    
    void Start()
    {
        E.enabled = false;

        cam1.SetActive(true);
        cam2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        float distanceToTExt = Vector3.Distance(transform.position, player.position);

        if (distanceToTExt <= radius) 
        {
            E.enabled = true;
            if (Input.GetKeyDown(KeyCode.E))
            {
                
                Debug.Log("je hebt E ingedrukt");
                cam1.SetActive(false);
                cam2.SetActive(true);
                Dot.SetActive(false);
                TaskBook.SetActive(false);
                VisibleCursor();
                TutorialScreen.SetActive(true);
                Time.timeScale = 0f;
            }
        }
        if (distanceToTExt >= radius)
        {
            E.enabled = false;
        }

        
         transform.LookAt(cam1.transform);
         transform.Rotate(0, 180, 0);
    }
    public void VisibleCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    
}
