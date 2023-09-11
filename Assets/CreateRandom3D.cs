using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateRandom3D : MonoBehaviour
{
    public GameObject[] objectsToClone; // An array to hold the 8 objects to clone.
    public int ObjectsToSpawn = 16; 
    public float moveSpeed = 2.0f;
    public float circleRadius = 2.0f;
    private int objectIndex = 0;
    private float timer = 0.0f;
    private float spawnInterval = 0.5f;

    private float angle = 0.0f; // Angle for circular movement.

    private void Start()
    {
        SpawnObject();
        spawnInterval = 0.5f;
    }

    private void Update()
    {
        timer += Time.deltaTime;

        angle += moveSpeed * Time.deltaTime;

        // Calculate the position for circular movement.
        Vector3 newPosition = transform.position + new Vector3(Mathf.Cos(angle) * circleRadius, 0.0f, Mathf.Sin(angle) * circleRadius);
        transform.position = newPosition;

        // Check if it's time to spawn objects.
        if (timer >= spawnInterval)
        {
            timer = 0.0f;
            SpawnObject();
        }
    }

    private void SpawnObject()
    {
        if (objectIndex < ObjectsToSpawn)
        {
            int randomIndex = Random.Range(0, objectsToClone.Length);
            GameObject currentObject = Instantiate(objectsToClone[randomIndex], transform.position + Vector3.right, Quaternion.identity);
            objectIndex++;

            float randomScale = Random.Range(0.5f, 3.0f);
            currentObject.transform.localScale = new Vector3(randomScale, randomScale, randomScale);

            // Adjust the spawn interval for the next set of objects.
            if (objectIndex == 3)
            {
                spawnInterval = 1.0f;
            }
            else if (objectIndex == 7)
            {
                spawnInterval = 1.5f;
            }
            else if (objectIndex == 11)
            {
                spawnInterval = 2.0f;
            }
            else if (objectIndex == 14)
            {
                spawnInterval = 2.5f;
            }
            else if (objectIndex == ObjectsToSpawn)
            {
                // Disable the script to stop spawning.
                enabled = false;
            }
        }
        else
        {
            // Disable the script to stop spawning.
            enabled = false;
        }
    }
}


