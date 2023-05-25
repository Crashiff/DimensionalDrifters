using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelFrameMovmentOuter : MonoBehaviour
{

    [SerializeField]
    Transform transformRot;

    [SerializeField]
    float zValue = 1;

    void FixedUpdate()
    {

        if (Input.GetKey(KeyCode.E))
        {
            transformRot.Rotate(0, 0, zValue);
        }
     
    }
}
