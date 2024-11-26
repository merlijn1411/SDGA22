using System.Collections;
using UnityEngine;

public class CursorActivator : MonoBehaviour
{
    
    public void CallCursor(bool OnTurningOn)
    {
        switch (OnTurningOn)
        {
            case true:
                StartCoroutine(CursorSwitcher(true,0.001f));
                break;
            case false:
                StartCoroutine(CursorSwitcher(false,0.00002f));
                break;
        }
    } 
    
    
    private IEnumerator CursorSwitcher(bool toggler,float timeInterval)
    {
        switch (toggler)
        {
            case true:
                yield return new WaitForSeconds(timeInterval);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                break;
            case false:
                yield return new WaitForSeconds(timeInterval);
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                break;
        }
        
    }
}

