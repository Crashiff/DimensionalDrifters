using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P1Movement : MonoBehaviour
{

    public Rigidbody2D rb;
    public float speed = 1.5f;
    public float jumpForce = 7f;
    private bool isGrounded = true;
    public LayerMask groundLayer;
    public Transform groundCheck;
    public float fallMultiplier = 3f;
    public float xAxis = 1.4f, yAxis = 1.1f;
    Vector2 vevGravity;

    // Start is called before the first frame update
    void Start()
    {
        vevGravity = new Vector2(0, -Physics2D.gravity.y);
    }

    void Update()
    {
        isGrounded = Physics2D.OverlapCapsule(groundCheck.position, new Vector2(xAxis, yAxis), CapsuleDirection2D.Horizontal, 0, groundLayer);

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.UpArrow) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.position += Vector3.down * speed * Time.deltaTime;
        }
        if (rb.velocity.y < 0)
        {
            Debug.Log(vevGravity);
            Debug.Log(fallMultiplier);

            rb.velocity -= vevGravity * fallMultiplier * Time.deltaTime;
        }
    }

}
