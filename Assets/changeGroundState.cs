using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeGroundState : MonoBehaviour
{
    public int current;
    public Transform transform;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.rotation.z < -50 || transform.rotation.z > 50)
            this.gameObject.layer = 0;
        else
            this.gameObject.layer = 6;
    }
}
