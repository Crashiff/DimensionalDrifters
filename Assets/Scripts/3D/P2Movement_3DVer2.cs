using UnityEngine;
using System.Collections;

public class P2Movement_3DVer2 : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    [SerializeField]
    private float playerSpeed = 2.0f;
    [SerializeField]
    private float jumpHeight = 1.0f;
    private float gravityValue = -9.81f;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void FixedUpdate()
    {
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        float inputX = Input.GetAxis("P2_Horizontal");
        float inputY = Input.GetAxis("P2_Vertical");

        Vector3 movement = controller.transform.forward * inputY;
        controller.transform.Rotate(Vector3.up * inputX * (50f * Time.deltaTime));
        controller.Move(movement * playerSpeed * Time.deltaTime);

        if (Input.GetButton("P2_Jump") && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }
}
