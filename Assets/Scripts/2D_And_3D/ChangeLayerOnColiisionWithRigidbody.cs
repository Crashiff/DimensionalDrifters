using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class ChangeLayerOnColiisionWithRigidbody : MonoBehaviour
{
    private GameObject colorChild;

    void Start()
    {
        colorChild = transform.Find("Color2D").gameObject;
    }

    private void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.name == "PlaneBuffer2D" && colorChild != null)
        {
            colorChild.layer = LayerMask.NameToLayer("2DPlane");
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.name == "PlaneBuffer2D" && colorChild != null)
        {
            colorChild.layer = LayerMask.NameToLayer("Default");
        }
    }
}
