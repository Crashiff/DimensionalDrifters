using UnityEngine;
using System.Collections;

public class P2Movement : MonoBehaviour {

    public float speed = 6.0F;
    public float jumpSpeed = 8.0F;
    public float gravity = 20.0F;
    public float fallMultiplierIncrement = 0.1f;
    private float fallMultiplier = 0.0f;
    private float jumpMultiplier = 0.0f;
    public float jumpMupltiplierDecrement = 0.1f;
    public Vector3 moveDirection = Vector3.zero;
    public bool justJumped = false;
    public bool wasGrounded = true;

    void FixedUpdate()
    {
        CharacterController controller = GetComponent<CharacterController>();
        moveDirection = new Vector3(Input.GetAxis("P2_Horizontal"), 0, 0);

        moveDirection = transform.TransformDirection(moveDirection);
        moveDirection *= speed;
        //Debug.Log("Fall multiplier: " + fallMultiplier);
        //Debug.Log("Jump multiplier: " + jumpMultiplier);
        if (controller.isGrounded)
        {
            wasGrounded = true;
            justJumped = false;
            //Debug.Log("if (controller.isGrounded)");
            if (Input.GetButton("P2_Jump"))
            {
                //Debug.Log("if (controller.isGrounded) if (Input.GetButton(\"P2_Jump\"))");
                fallMultiplier = 0.0f;
                jumpMultiplier = 0.0f;
                moveDirection.y = jumpSpeed;
                justJumped = true;

            }
            if (wasGrounded == true)
            {
                //Debug.Log("if (controller.isGrounded) if (wasGrounded == true)");
                wasGrounded = false;
                fallMultiplier = 0.0f;
                jumpMultiplier = 0.0f;
                moveDirection.y = 0.0f;
            }
        }

        else if (justJumped && !controller.isGrounded)
        {
            //Debug.Log("else if (justJumped && !controller.isGrounded) if (wasGrounded == true)");
            if (wasGrounded == true)
            {
                //Debug.Log("if (controller.isGrounded) if (wasGrounded == true)");
                wasGrounded = false;
                fallMultiplier = 0.0f;
                jumpMultiplier = 0.0f;
                moveDirection.y = 0.0f;
            }
            moveDirection.y += jumpSpeed - jumpMultiplier;
            jumpMultiplier += jumpMupltiplierDecrement;
        }
        else if (justJumped && controller.isGrounded)
        {
            //Debug.Log("else if (justJumped && controller.isGrounded)");
            justJumped = false;
            fallMultiplier = 0.0f;
            jumpMultiplier = 0.0f;
        }
        else if (!controller.isGrounded)
        {
            //Debug.Log("else if (!controller.isGrounded)");
            justJumped = false;
            moveDirection.y = -(gravity + fallMultiplier);
            fallMultiplier += fallMultiplierIncrement;
        }

        controller.Move(moveDirection * Time.deltaTime);

    }

    void OnCollisionEnter(Collision collision) 
    {
        jumpMultiplier = System.Math.Max(jumpSpeed, jumpMultiplier);
        Debug.Log("hello");
    }
}
