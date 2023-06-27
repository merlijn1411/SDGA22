using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Door : MonoBehaviour
{
    public bool isAuto;
    public Animator ani;
    private bool canBeOpened;

    private void OnMouseDown()
    {
        if (canBeOpened)
        {
            ani.SetBool("Open", true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && isAuto)
        {
            ani.SetBool("Open", true);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && !isAuto)
        {
            canBeOpened = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            ani.SetBool("Open", false);
            canBeOpened = false;
        }
    }
}
