using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    public GameObject playerCamera;
    public float rotationSpeed ;

    
    void Start()
    {
        
    }
    void Update()
    {
        Vector2 input = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

        transform.Rotate(0, input.x * rotationSpeed, 0);

        playerCamera.transform.Rotate(-input.y * rotationSpeed, 0, 0);

    }
}
