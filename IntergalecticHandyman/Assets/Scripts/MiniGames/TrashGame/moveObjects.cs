using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class moveObjects : MonoBehaviour
{
    private Vector3 mOffset;
    private float mZcoord;
    public Camera secondCam;
    private Rigidbody rb;

    private void OnMouseDown()
    {
        mZcoord = secondCam.WorldToScreenPoint(gameObject.transform.position).z;
        mOffset = gameObject.transform.position - GetMouseWorldPos();
    }

    private Vector3 GetMouseWorldPos()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = mZcoord;
        return secondCam.ScreenToWorldPoint(mousePoint);
    }

    private void OnMouseDrag()
    {
        transform.position = GetMouseWorldPos() + mOffset;
    }
    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.CompareTag("Wall"))
        {
           
            Rigidbody otherRb = collision.gameObject.GetComponent<Rigidbody>();

            
            otherRb.velocity = -otherRb.velocity;
        }
    }
}
