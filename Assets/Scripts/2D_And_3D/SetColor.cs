using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetColor : MonoBehaviour
{
    public Color InsideColor;

    void Start()
    {
        Renderer renderer = GetComponent<Renderer>();
        renderer.material.SetColor("_CutoffColor", InsideColor);
    }
}
