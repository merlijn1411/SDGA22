using UnityEngine;


public class Door : MonoBehaviour
{
    public bool isAuto;
    public Animator ani;
    private bool canBeOpened;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && isAuto)
        {
            ani.SetBool("Open", true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && isAuto) 
        {
            ani.SetBool("Open", false);
            canBeOpened = false;
        }
    }
}
