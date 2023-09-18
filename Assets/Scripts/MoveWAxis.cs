using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWAxis : MonoBehaviour
{
    [SerializeField] private float speed = 0.01f;
    private void OnTriggerStay(Collider other)
    {
        // Check if the collider has the tag "Player1" or "Player2."
        if (other.CompareTag("Player1") || other.CompareTag("Player2"))
        {
            // Find all objects on the "4DPlane" layer.
            GameObject[] objectsOn4DPlane = GameObject.FindGameObjectsWithTag("Shape4D");

            // Loop through all the found objects and change their W_Axis value.
            foreach (GameObject planeObject in objectsOn4DPlane)
            {

                Hypersphere hypersphereScript = planeObject.GetComponent<Hypersphere>();

                if (hypersphereScript != null)
                {
                    // Increase the W_Axis value in the Hypersphere script by 0.1f.
                    if (hypersphereScript.W_Axis + speed < 2.0f && hypersphereScript.W_Axis + speed > 0.0f)
                    {
                        hypersphereScript.W_Axis += speed;
                    }

                }
            }

        GameObject theTesseract = GameObject.Find("TheTesseract");

        if (theTesseract != null)
        {
            
            Transform tesseractTransform = theTesseract.transform;
            tesseractTransform.position = new Vector3(tesseractTransform.position.x + (speed * 40), tesseractTransform.position.y, tesseractTransform.position.z);
        }
        else
        {
            Debug.LogError("Object 'TheTesseract' not found.");
        }
        }
    }
}
