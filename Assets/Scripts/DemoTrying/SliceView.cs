using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class SliceView : MonoBehaviour
{
    public Material mat;
    public string PlaneName = "_Plane";

    void Update()
    {
        Plane plane = new Plane(transform.up, transform.position);
        Vector4 planeRepresentation = new Vector4(plane.normal.x, plane.normal.y, plane.normal.z, plane.distance);
        mat.SetVector(PlaneName, planeRepresentation);
    }
}
