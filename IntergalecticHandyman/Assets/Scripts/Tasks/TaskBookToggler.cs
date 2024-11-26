using System;
using UnityEngine;

public class TaskBookToggler : MonoBehaviour
{
    [SerializeField] private GameObject taskBook;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            Toggle();
        }
    }

    private void Toggle()
    {
        taskBook.SetActive(!taskBook.activeSelf);
    }
}
