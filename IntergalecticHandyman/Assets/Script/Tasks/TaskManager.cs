using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Cursor = UnityEngine.Cursor;

public class TaskManager : MonoBehaviour
{
    private GameCamsChecker gameCamsChecker;
    [SerializeField] private Toggle trashToggle;
    [SerializeField] private Toggle pipeToggle;
    [SerializeField] private List<string> tasks;
    [SerializeField] private TMP_Text taskText;

    public UnityEvent onAllTasksCompleted;
    
    private int completeHoldTasks = 0;

    private bool _pipeGameCompleted = false;
    private bool _trashGameCompleted = false;
    
    private void Start()
    {
        gameCamsChecker = GetComponent<GameCamsChecker>();

        taskText.text = $"{completeHoldTasks}/{tasks.Count}";
    }

    private void Update()
    {
        if (_trashGameCompleted && _pipeGameCompleted && completeHoldTasks == tasks.Count)
        {
            onAllTasksCompleted.Invoke();
        }
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
        _trashGameCompleted = true;
        CursorOff();
        trashToggle.isOn = true;
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
        _pipeGameCompleted = true;
        CursorOff();
        pipeToggle.isOn = true;
    }

    public void CompleteHoldTask()
    {
        completeHoldTasks++;
        
        taskText.text = $"{completeHoldTasks}/{tasks.Count}";
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
