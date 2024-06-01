using UnityEngine;
using UnityEngine.Events;

public class DoInteraction : MonoBehaviour
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
        print("boem");
    }
}
