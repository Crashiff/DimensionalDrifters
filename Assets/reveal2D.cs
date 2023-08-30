using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reveal2D : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private Transform backgroundTransform;
    private float speed = 1.0f;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (backgroundTransform.position.y < 10) 
        {
            backgroundTransform.position = new Vector3(backgroundTransform.position.x, backgroundTransform.position.y + (speed * Time.deltaTime), backgroundTransform.position.z);
        }  
    }
}
