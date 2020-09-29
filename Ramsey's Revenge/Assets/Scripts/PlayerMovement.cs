using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public LayerMask platformsLayerMask;
    private Rigidbody2D rigidbody2d;
    private BoxCollider2D boxCollider2d;
    public float moveSpeed = 80f;
    public float jumpVelocity = 200f;
    private float movement;
    private Vector2 velocity;

    private void Start()
    {
        rigidbody2d = transform.GetComponent<Rigidbody2D>();
        boxCollider2d = transform.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        // Move Code
        if (Input.GetButton("Horizontal"))
        {
            movement = Input.GetAxisRaw("Horizontal");
            rigidbody2d.velocity = new Vector2((movement * moveSpeed), rigidbody2d.velocity.y);
        }
        if (Input.GetButtonUp("Horizontal"))
        {
            rigidbody2d.velocity = new Vector2(0f, rigidbody2d.velocity.y);
        }

        // Jump Code
        if (IsGrounded() && Input.GetKeyDown(KeyCode.W))
        {
            rigidbody2d.velocity = new Vector2(rigidbody2d.velocity.x, jumpVelocity);
        }
    }

    private bool IsGrounded()
    {
        RaycastHit2D raycastHit2d = Physics2D.BoxCast(boxCollider2d.bounds.center, boxCollider2d.bounds.size, 0f, Vector2.down, .1f, platformsLayerMask);
        return raycastHit2d.collider != null;
    }
}
