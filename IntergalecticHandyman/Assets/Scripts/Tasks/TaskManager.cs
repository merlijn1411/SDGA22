using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

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
        CamToggler(0, true);
    }

    public void TrashTaskDone()
    {
        CamToggler(0, false);
        _trashGameCompleted = true;
        trashToggle.isOn = _trashGameCompleted;
    }

    public void StartPipelineTask()
    {
        CamToggler(1, true);
    }

    public void PipelineTaskDone()
    {
        CamToggler(1, false);
        _pipeGameCompleted = true;
        pipeToggle.isOn = _pipeGameCompleted;
    }
    private void CamToggler(int camList, bool isTaskStarting)
    {
        switch (isTaskStarting)
        {
            case true:
                gameCamsChecker.mainCam.enabled = false;
                gameCamsChecker.secCams[camList].enabled = true;
                break;
            case false:
                gameCamsChecker.mainCam.enabled = true;
                gameCamsChecker.secCams[camList].enabled = false;
                break;
        } 
    }
    
    public void HoldTaskUpdater()
    {
        completeHoldTasks++;
        taskText.text = $"{completeHoldTasks}/{tasks.Count}";
    }

    
}
