using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCanvas : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Canvas;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(Canvas.transform);
        transform.Rotate(0, 180, 0);
    }
}
