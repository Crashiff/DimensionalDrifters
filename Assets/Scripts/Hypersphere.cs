using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class Hypersphere : MonoBehaviour
{

    //TODO: Add W-Width to 4D Hypersphere
    [SerializeField]
    private GameObject HypersphereOuter;

    [SerializeField]
    public float W_Axis = 1.0f;

    private void Update()
    {
        // Ensure size is at least -1.
        float clampedSize = Mathf.Max(W_Axis, 0.0f);
        if (clampedSize <= 2.0f && clampedSize > 1.0f)
        {
            clampedSize = 1.0f + (1.0f - clampedSize);
        } else if (clampedSize > 2.0f) {
            clampedSize = 0.0f;
        }

        // Set the scale of HypersphereOuter with the same value for x, y, and z.
        transform.localScale = new Vector3(clampedSize, clampedSize, clampedSize);
    }

}
