using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P1Movement : MonoBehaviour
{

    [SerializeField]
    Rigidbody2D rb;

    [SerializeField]
    float speed = 1.5f;

    [SerializeField]
    float jumpForce = 7f;

    [SerializeField]
    LayerMask groundLayer;

    [SerializeField]
    Transform groundCheck;

    [SerializeField]
    float fallMultiplier = 3f;

    [SerializeField]
    float xAxis = 1.4f, yAxis = 1.1f; //sizes of the player

    private bool isGrounded = true;
    private Vector2 vevGravity;

    // Start is called before the first frame update
    void Start()
    {
        vevGravity = new Vector2(0, -Physics2D.gravity.y);
    }

    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCapsule(groundCheck.position, new Vector2(xAxis, yAxis), CapsuleDirection2D.Horizontal, 0, groundLayer);

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.MovePosition(transform.position + Vector3.left * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.MovePosition(transform.position += Vector3.right * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.UpArrow) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            rb.MovePosition(transform.position += Vector3.down * speed * Time.deltaTime);
        }
        //if (rb.velocity.y < 0)
        //{
        //    Debug.Log(vevGravity);
        //    Debug.Log(fallMultiplier);

        //    rb.MovePosition(rb.velocity -= vevGravity * fallMultiplier * Time.deltaTime);
        //}
    }

}
