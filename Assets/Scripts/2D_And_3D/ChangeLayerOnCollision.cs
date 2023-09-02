using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class ChangeLayerOnCollision : MonoBehaviour
{
    private void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.name == "PlaneBuffer2D")
        {
            gameObject.layer = LayerMask.NameToLayer("2DPlane");
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.name == "PlaneBuffer2D")
        {
            gameObject.layer = LayerMask.NameToLayer("Default");
        }
    }
}
