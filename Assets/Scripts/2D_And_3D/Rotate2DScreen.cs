using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate2DScreen : MonoBehaviour
{

    public Transform ScreenTransfrom;
    public float Speed = 1f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.E))
        {
            ScreenTransfrom.Rotate(0, 0, Speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.Q))
        {
            ScreenTransfrom.Rotate(0, 0, -Speed * Time.deltaTime);
        }
    }
}
