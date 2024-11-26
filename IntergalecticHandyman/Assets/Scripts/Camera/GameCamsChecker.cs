using UnityEngine;


public class GameCamsChecker : MonoBehaviour
{
    public Camera mainCam;
    public Camera[] secCams;
    private void Start()
    {
        DisableSecCams();
    }

    private void DisableSecCams()
    {
        foreach (var t in secCams)
        {
            t.enabled = false;
        }
    }
}
