using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelFrameMovmentOuter : MonoBehaviour
{

    public Transform transform;
    public float zValue = 1;

    void Update()
    {

        if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(0, 0, zValue);
        }
     
    }
}
