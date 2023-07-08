using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlattenObject : MonoBehaviour
{
    public float flattenValue = 0.5f; // Adjust the flatten value for each object as desired
    

    void Update()
    {
        Renderer renderer = GetComponent<Renderer>();
        MaterialPropertyBlock mpb = new MaterialPropertyBlock();
        mpb.SetFloat("_FlattenValue", flattenValue);
        renderer.SetPropertyBlock(mpb);
    }
}
