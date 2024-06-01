using UnityEngine;

public class StartTask : MonoBehaviour
{
    [SerializeField] private GameCamsChecker gameCamsChecker;
    public void StartTrashTask()
    {
        gameCamsChecker.mainCam.enabled = false;
        gameCamsChecker.secCams[0].enabled = true;
        CursorOn();
    }

    public void StartPipelineTask()
    {
        gameCamsChecker.mainCam.enabled = false;
        gameCamsChecker.secCams[1].enabled = true;
        CursorOn();
    }

    private static void CursorOn()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
