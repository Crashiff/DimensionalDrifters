using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuAnimationsHandler : MonoBehaviour
{
public GameObject cubePrefab;
    public float spawnInterval = 5f; // Time between cube spawns
    public float rotationDuration = 3f; // Duration for cube rotation
    private float rotationTimer;

    public RectTransform spawnRect;
    public Vector3 cubeSize = new Vector3(1f, 1f, 1f);

    private void Start()
    {
        rotationTimer = rotationDuration;
        SpawnCube();
    }

    private void Update()
    {
        rotationTimer -= Time.deltaTime;

        if (rotationTimer <= 0f)
        {
            rotationTimer = rotationDuration;
            //SpawnCube();
        }
    }

    private void SpawnCube()
    {
        Vector3 spawnPosition = new Vector3(spawnRect.position.x, spawnRect.position.y, spawnRect.position.z);
        GameObject cube = Instantiate(cubePrefab, spawnPosition, Quaternion.identity);
        // Set the size of the spawned cube
        cube.transform.localScale = cubeSize;

        // Make the cube a child of the MainMenu canvas
        cube.transform.SetParent(transform);

        Destroy(cube, rotationDuration + 1f); // Destroy after rotation plus 1 second
    }
}    
