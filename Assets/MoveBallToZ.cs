using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBallToZ : MonoBehaviour
{
    // Reference to the ball GameObject with a Rigidbody.
    public GameObject ball;
    
    // The force value to apply to the Z-axis.
    public float forceAmount = 1.0f;

    // Reference to the Rigidbody component of the ball.
    private Rigidbody ballRigidbody;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEnter");
        if (other.gameObject.tag != "Player1" && other.gameObject.tag != "Player2")
        {
            return;
        }
        Debug.Log("OnTriggerEnter player");
        if (ball != null)
        {
            ballRigidbody = ball.GetComponent<Rigidbody>();

            // Check if the ball has a Rigidbody component.
            if (ballRigidbody != null)
            {
                // Unlock the Z-axis rotation by setting constraints.
                ballRigidbody.constraints &= ~RigidbodyConstraints.FreezePositionZ;
            }
            else
            {
                Debug.LogError("The 'ball' GameObject does not have a Rigidbody component.");
            }
        }
        else
        {
            Debug.LogError("Please assign the 'ball' GameObject in the Inspector.");
        }


        Debug.Log("force added " + forceAmount);
        // Apply force to the Z-axis.
        ballRigidbody.AddForce(Vector3.forward * forceAmount, ForceMode.Impulse);
    }
}
