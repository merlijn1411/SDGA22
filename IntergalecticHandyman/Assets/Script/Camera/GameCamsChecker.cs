using UnityEngine;
using UnityEngine.Serialization;

public class GameCamsChecker : MonoBehaviour
{
    [SerializeField] private Camera mainCam;
    [SerializeField] private Camera[] secCams;
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
