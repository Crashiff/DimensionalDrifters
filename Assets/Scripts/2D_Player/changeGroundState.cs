using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeGroundState : MonoBehaviour
{
    [SerializeField]
    int current;

    [SerializeField] Transform 
        transformRot;

    // Update is called once per frame
    void Update()
    {
        if (transformRot.rotation.z < -50 || transformRot.rotation.z > 50)
            this.gameObject.layer = 0;
        else
            this.gameObject.layer = 6;
    }
}
