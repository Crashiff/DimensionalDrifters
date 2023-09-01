using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trySlice : MonoBehaviour
{
    void Start()
    {
        // Get the Mesh component from the object
        Mesh mesh = GetComponent<MeshFilter>().mesh;

        // Get the normals array from the Mesh
        Vector3[] normals = mesh.normals;

        // Print the normals
        for (int i = 0; i < normals.Length; i++)
        {
            Debug.Log("Normal " + i + ": " + normals[i]);
        }
    }

    void Update()
    {
        
    }
}
