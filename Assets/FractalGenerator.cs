using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FractalGenerator : MonoBehaviour
{
    public GameObject fractalCubePrefab;
    public int recursionDepth = 3;
    public float scaleFactor = 0.5f;

    public float delay = 1f;

    void Start()
    {
        GenerateFractal(transform.position, Quaternion.identity, Vector3.one, recursionDepth);
    }

    void GenerateFractal(Vector3 position, Quaternion rotation, Vector3 scale, int depth)
    {
        if (depth <= 0)
            return;

        GameObject cube = Instantiate(fractalCubePrefab, position, rotation);
        cube.transform.localScale = scale;

        // Recursively generate child cubes
        for (int i = 0; i < 8; i++)
        {
            Vector3 offset = new Vector3(
                (i & 1) == 0 ? scaleFactor : -scaleFactor,
                (i & 2) == 0 ? scaleFactor : -scaleFactor,
                (i & 4) == 0 ? scaleFactor : -scaleFactor
            );

            GenerateFractal(position + offset * 0.5f, Quaternion.identity, scale * scaleFactor, depth - 1);
            Destroy(cube, delay);
            Invoke("RecreateFractal", delay);
        }
    }
    void RecreateFractal()
    {
        // Recreate the fractal after the delay
        GenerateFractal(transform.position, Quaternion.identity, Vector3.one, recursionDepth);
    }
    
}