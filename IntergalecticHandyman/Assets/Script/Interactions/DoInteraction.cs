using UnityEngine;
using UnityEngine.Events;

public class DoInteraction : MonoBehaviour
{
    public UnityEvent startInteraction;
    void Update()
    {
        StartInteraction();
    }

    private void StartInteraction()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            startInteraction.Invoke();
            print("boem");
        }
    }
}
