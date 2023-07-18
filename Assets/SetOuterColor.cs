using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class SetOuterColor : MonoBehaviour
{
    public Color OuterColor;

    void Update()
    {
        Renderer renderer = GetComponent<Renderer>();
        renderer.material.SetColor("_Color", OuterColor);
    }
}
