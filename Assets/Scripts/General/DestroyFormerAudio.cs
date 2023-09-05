using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyFormerAudio : MonoBehaviour
{
    public string nameOfToDestoryObject;
    void Start()
    {

        Destroy(GameObject.Find(nameOfToDestoryObject));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
