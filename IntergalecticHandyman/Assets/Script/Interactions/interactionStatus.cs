using UnityEngine;
using UnityEngine.Events;

public class interactionStatus : MonoBehaviour
{
    public UnityEvent startInteraction;
    private void Update()
    {
        StartInteraction();
    }

    private void StartInteraction()
    {
        if (!Input.GetKeyDown(KeyCode.E)) return;
        startInteraction.Invoke();
    }

    public void InteractionTaskDone()
    {
        Destroy(gameObject);
    }
}
