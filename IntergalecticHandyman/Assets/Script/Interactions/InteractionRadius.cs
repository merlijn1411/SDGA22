using TMPro;
using UnityEngine;  


public class InteractionRadius : MonoBehaviour
{
    // public float radius;
    // public TextMeshProUGUI E;
    // public Transform player;
    //
    // public GameObject Dot;
    //
    // public GameObject TaskBook;
    //
    // public GameObject cam1;
    // public GameObject cam2;
    
    [SerializeField] private Transform player;
    [SerializeField] private TextMeshPro interactionText;
    [SerializeField] private float radius;
    
    
    void Update()
    {
        InRadius();
        // float distanceToTExt = Vector3.Distance(this.transform.position, player.position);
        //
        // if (distanceToTExt <= radius) 
        // {
        //     E.enabled = true;
        //     if (Input.GetKeyDown(KeyCode.E))
        //     {
        //         Time.timeScale = 1f;
        //         Debug.Log("je hebt E ingedrukt");
        //         cam1.SetActive(false);
        //         cam2.SetActive(true);
        //         Dot.SetActive(false);
        //         TaskBook.SetActive(false);
        //         VisibleCursor();
        //         
        //     }
        // }
        // if (distanceToTExt >= radius)
        // {
        //     E.enabled = false;
        // }
        //
        //
        // this.transform.LookAt(cam1.transform);
        // this.transform.Rotate(0, 180, 0);
    }

    private void InRadius()
    {
        var distanceToTarget = Vector3.Distance(interactionText.transform.position, player.position);

        var targetAlpha = distanceToTarget < radius ? 255 : 0;
        interactionText.color = new Color(255, 255, 255, targetAlpha);
    }
}
