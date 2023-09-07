using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour
{
    public static bool useFolder1 = true;

    public static void SwitchMaterials()
    {
        useFolder1 = !useFolder1;

        // Find all objects in the scene and update their materials
        Renderer[] renderers = FindObjectsOfType<Renderer>();
        foreach (Renderer renderer in renderers)
        {
            if (useFolder1)
            {
                Debug.Log("Assets/Materials/Standard/" + renderer.sharedMaterial.name + ".mat");
                renderer.material = Resources.Load<Material>("Materials/Standard/" + renderer.sharedMaterial.name);
            }
            else
            {
                Debug.Log("Assets/Materials/Cartoon/" + renderer.sharedMaterial.name + ".mat");
                renderer.material = Resources.Load<Material>("Materials/Cartoon/" + renderer.sharedMaterial.name);
            }
        }
    }
}
