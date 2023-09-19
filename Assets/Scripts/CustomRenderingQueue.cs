using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomRenderingQueue : MonoBehaviour
{
    public int customQueueOffsetMaterial1 = 0; // Custom rendering queue offset for Material 1
    public int customQueueOffsetMaterial2 = 0; // Custom rendering queue offset for Material 2
    public Renderer theRenderer; // Reference to the Renderer component on the GameObject

    void Start()
    {
        if (theRenderer != null)
        {
            Material[] materials = theRenderer.sharedMaterials;

            if (materials.Length >= 2)
            {
                Material newMaterial1 = new Material(materials[0]);
                newMaterial1.renderQueue = customQueueOffsetMaterial1;

                Material newMaterial2 = new Material(materials[1]);
                newMaterial2.renderQueue = customQueueOffsetMaterial2;

                materials[0] = newMaterial1;
                materials[1] = newMaterial2;

                theRenderer.sharedMaterials = materials;
            }
        }
    }
}