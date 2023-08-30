using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuAnimationsHandler : MonoBehaviour
{
public GameObject cubePrefab;
    public float rotationDuration = 3f; // Duration for cube rotation
    private float rotationTimer;

    public RectTransform spawnRect;
    public Vector3 cubeSize = new Vector3(1f, 1f, 1f);
    private float initTime;
    private GameObject cube;
    
    ActiveAnimation currentAnimation = ActiveAnimation.NothingActive;

    private void Start()
    {
        initTime = Time.time;
        rotationTimer = rotationDuration;
        SpawnCube();
        currentAnimation = ActiveAnimation.Cube3D;
    }

    private void Update()
    {

        if (Time.time - initTime >= 25f)
        {
            Destroy(cube);
            currentAnimation = ActiveAnimation.NothingActive;
            initTime = Time.time;
            //rotationTimer = rotationDuration;
            //SpawnCube();
        }

        if (currentAnimation == ActiveAnimation.Cube3D)
        {
            handle3D();
        }
        else if (currentAnimation == ActiveAnimation.Cube1D)
        {
            handle1D();
        }
        else if (currentAnimation == ActiveAnimation.NothingActive)
        {
            SpawnCube();
        }
        
    }

    private void SpawnCube()
    {
        Vector3 spawnPosition = new Vector3(spawnRect.position.x, spawnRect.position.y, spawnRect.position.z);
        cube = Instantiate(cubePrefab, spawnPosition, Quaternion.identity);
        cube.transform.localScale = cubeSize;
        cube.transform.SetParent(transform);

        int randomValue = Random.Range(1, 4);
        if (randomValue == 1) {
            currentAnimation = ActiveAnimation.Cube3D;
        }
        else {
            currentAnimation = ActiveAnimation.Cube1D;
        }
    }

    private void handle3D()
    {
        cube.transform.Rotate(Vector3.up * (50f * Time.deltaTime));
        cube.transform.position = new Vector3(cube.transform.position.x - (1f * Time.deltaTime), cube.transform.position.y, cube.transform.position.z);
    }

       private void handle1D()
    {
        cube.transform.position = new Vector3(cube.transform.position.x - (1f * Time.deltaTime), cube.transform.position.y, cube.transform.position.z);
    } 

    enum ActiveAnimation{
        Cube1D,
        Cube2D,
        Cube3D,
        NothingActive
    }
}    
