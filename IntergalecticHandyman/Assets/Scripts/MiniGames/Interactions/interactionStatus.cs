using UnityEngine;
using UnityEngine.Events;

public class interactionStatus : MonoBehaviour
{
    public UnityEvent startInteraction;
    public UnityEvent cancelInteraction;
    private void Update()
    {
        StartInteraction();
    }

    private void StartInteraction()
    {
        if (Input.GetKeyDown(KeyCode.E)) 
            startInteraction.Invoke();
        else if (Input.GetKeyUp(KeyCode.E))
            cancelInteraction.Invoke();
        
    }

    public void InteractionTaskDone()
    {
        Destroy(gameObject);
    }
}
