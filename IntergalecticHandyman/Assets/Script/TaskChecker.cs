using System;
using UnityEngine;

public class TaskChecker : MonoBehaviour
{
    private GameCamsChecker gameCamsChecker;

    private void Start()
    {
        gameCamsChecker = GetComponent<GameCamsChecker>();
    }

    public void StartTrashTask()
    {
        gameCamsChecker.mainCam.enabled = false;
        gameCamsChecker.secCams[0].enabled = true;
        CursorOn();
    }
    
    public void TrashTaskDone()
    {
        gameCamsChecker.mainCam.enabled = true;
        gameCamsChecker.secCams[0].enabled = false;
        CursorOff();
    }

    public void StartPipelineTask()
    {
        gameCamsChecker.mainCam.enabled = false;
        gameCamsChecker.secCams[1].enabled = true;
        CursorOn();
    }

    public void PipelineTaskDone()
    {
        gameCamsChecker.mainCam.enabled = true;
        gameCamsChecker.secCams[1].enabled = false;
        CursorOff();
    }

    private static void CursorOn()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    private static void CursorOff()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
