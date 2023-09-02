using UnityEngine;
using System.Collections;

public class P1Movement : MonoBehaviour
{
    public float speed = 6.0F;
    public float jumpSpeed = 8.0F;
    public float gravity = 20.0F;
    public float fallMultiplierIncrement = 0.1f;
    private float fallMultiplier = 0.0f;
    private float jumpMultiplier = 0.0f;
    public float jumpMupltiplierDecrement = 0.1f;
    private Vector3 moveDirection = Vector3.zero;
    public bool justJumped = false;

    void FixedUpdate()
    {
        CharacterController controller = GetComponent<CharacterController>();
        moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, 0);

        moveDirection = transform.TransformDirection(moveDirection);
        moveDirection *= speed;

        if (controller.isGrounded)
        {
            if (Input.GetButton("Jump"))
            {
                gameObject.GetComponent<AudioSource>().Play();
                fallMultiplier = 0.0f;
                jumpMultiplier = 0.0f;
                moveDirection.y = jumpSpeed;
                justJumped = true;
            }
        }

        else if (justJumped && !controller.isGrounded)
        {
            moveDirection.y += jumpSpeed - jumpMultiplier;
            jumpMultiplier += jumpMupltiplierDecrement;
        }
        else if (justJumped && controller.isGrounded)
        {
            justJumped = false;
            fallMultiplier = 0f;
            jumpMultiplier = 0.0f;
        }
        else if (!controller.isGrounded)
        {
            moveDirection.y = -(gravity + fallMultiplier);
            fallMultiplier += fallMultiplierIncrement;
        }

        controller.Move(moveDirection * Time.deltaTime);

    }
}
