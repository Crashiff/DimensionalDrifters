using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float playerSpeed;
    public float DeathDistance;
    public float jumpForce = 10f; // New variable for jump force

    private Vector3 StartPos;
    private bool endGame = false;

    private void Start()
    {
        StartPos = transform.position;
    }

    void Update()
    {
        if (transform.position.y < DeathDistance)
        {
            transform.position = StartPos;
        }
        if (!endGame)
        {
            MovePlayer();
            CheckJump(); // Check for jump input
        }
    }

    void MovePlayer()
    {
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            Vector3 direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized;
            transform.Translate(direction * Time.deltaTime * playerSpeed, Space.World);
            transform.LookAt(direction + transform.position);
        }
    }

    void CheckJump()
    {
        if (Input.GetButton("Jump"))
        {
            Jump();
        }
    }

    void Jump()
    {
        Rigidbody rb = GetComponent<Rigidbody>(); // Assuming your player has a Rigidbody
        if (rb != null)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    public void EndGame()
    {
        endGame = true;
    }
}
