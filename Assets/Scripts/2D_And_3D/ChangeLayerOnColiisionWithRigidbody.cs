using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class ChangeLayerOnColiisionWithRigidbody : MonoBehaviour
{
    //private GameObject buffer;
    private GameObject prepareChild;
    private GameObject colorChild;

    void Start()
    {
        prepareChild = transform.Find("Prepare2D").gameObject;
        colorChild = transform.Find("Color2D").gameObject;
    }

    private void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.name == "PlaneBuffer2D")
        {
            prepareChild.layer = LayerMask.NameToLayer("2DPlane");
            colorChild.layer = LayerMask.NameToLayer("2DPlane");
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.name == "PlaneBuffer2D")
        {
            prepareChild.layer = LayerMask.NameToLayer("Default");
            colorChild.layer = LayerMask.NameToLayer("Default");
        }
    }
}
