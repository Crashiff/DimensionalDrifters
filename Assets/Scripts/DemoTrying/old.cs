using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P2Movment : MonoBehaviour
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
    //float xAxis = 1.4f, yAxis = 1.1f;

    private bool isGrounded = true;

    [SerializeField]
    float distToGround;
    private Vector2 vevGravity;

    void Start()
    {
        vevGravity = new Vector2(0, -Physics2D.gravity.y);
        distToGround = GetComponent<Collider2D>().bounds.extents.y;
    }

     bool IsGrounded()
    {
        return Physics.CheckCapsule(GetComponent<Collider2D>().bounds.center, new Vector3(GetComponent<Collider2D>().bounds.center.x, GetComponent<Collider2D>().bounds.min.y - 0.1f, GetComponent<Collider2D>().bounds.center.z), 0.18f);
    }


void FixedUpdate()
    {

        //isGrounded = Physics2D.OverlapCapsule(groundCheck.position, new Vector2(xAxis, yAxis), CapsuleDirection2D.Horizontal,0,groundLayer);
        isGrounded = IsGrounded();

        if (Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.W) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += Vector3.down * speed * Time.deltaTime;
        }
        if(rb.velocity.y < 0)
        {
            rb.velocity -= vevGravity * fallMultiplier * Time.deltaTime;
        }
    }
}
