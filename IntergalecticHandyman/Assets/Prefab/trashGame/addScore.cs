using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class addScore : MonoBehaviour
{
    public int score = 0;
    private showRadius GamecameraScript;
    

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
