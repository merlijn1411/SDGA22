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
        for (int i = 0; i < secCams.Length; i++)
        {
            secCams[i].enabled = false;
        }
    }
}
