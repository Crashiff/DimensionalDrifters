using UnityEngine;

public class FallingScript : MonoBehaviour
{
    // The target position where the object should land
    public Vector3 targetPosition;

    // The duration of the fall in seconds
    public float fallDuration = 2.0f;

    private Vector3 initialPosition;
    public bool isFalling = false;
    private float elapsedTime = 0.0f;

    private void Start()
    {
        // Store the initial position of the object
        initialPosition = transform.position;
    }

    private void Update()
    {
        // If the object is currently falling, update its position
        if (isFalling)
        {
            elapsedTime += Time.deltaTime;

            // Calculate the normalized progress of the fall
            float fallProgress = Mathf.Clamp01(elapsedTime / fallDuration);

            // Interpolate the object's position from initial to target position
            transform.position = Vector3.Lerp(initialPosition, targetPosition, fallProgress);

            // Check if the fall has reached its target
            if (fallProgress >= 1.0f)
            {
                // Stop the fall
                isFalling = false;
            }
        }
    }

    public void StartFalling()
    {
        Debug.Log("falling");
        // Set the flag to indicate that the object is falling
        isFalling = true;
        elapsedTime = 0.0f;
    }
}
