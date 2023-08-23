using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reveal2D : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private Transform transform;
    private float speed = 1.0f;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (transform.position.y < 10) 
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + (speed * Time.deltaTime), transform.position.z);
        }  
    }
}
