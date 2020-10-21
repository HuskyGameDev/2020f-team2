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
    private float gravity;
    public Sprite left;
    public Sprite right;

    private void Start()
    {
        rigidbody2d = transform.GetComponent<Rigidbody2D>();
        boxCollider2d = transform.GetComponent<BoxCollider2D>();
        gravity = rigidbody2d.gravityScale;
    }

    // Update is called once per frame
    private void Update()
    {
        // Move Code
        movement = Input.GetAxis("Horizontal");

        if (IsGrounded())
        {
            rigidbody2d.gravityScale = 0f;
            rigidbody2d.velocity = new Vector2(0f, 0f);
        }
        else
        {
            rigidbody2d.gravityScale = gravity;
        }

        if (Input.GetKey(KeyCode.A))
        {
            rigidbody2d.velocity = new Vector2(Vector2.left.x * moveSpeed, rigidbody2d.velocity.y);
            this.gameObject.GetComponent<Animator>().enabled = true;
            this.gameObject.GetComponent<Animator>().Play("MoveLeft");
        }
        else if (Input.GetKey(KeyCode.D))
        {
            rigidbody2d.velocity = new Vector2(Vector2.right.x * moveSpeed, rigidbody2d.velocity.y);
            this.gameObject.GetComponent<Animator>().enabled = true;
            this.gameObject.GetComponent<Animator>().Play("MoveRight");
        }

        if (Input.GetKeyUp(KeyCode.A))
        {
            rigidbody2d.velocity = new Vector2(0f, rigidbody2d.velocity.y);
            this.gameObject.GetComponent<Animator>().enabled = false;
            this.gameObject.GetComponent<SpriteRenderer>().sprite = left;
        }

        if (Input.GetKeyUp(KeyCode.D))
        {
            rigidbody2d.velocity = new Vector2(0f, rigidbody2d.velocity.y);
            this.gameObject.GetComponent<Animator>().enabled = false;
            this.gameObject.GetComponent<SpriteRenderer>().sprite = right;
        }

        // Jump Code
        if (IsGrounded() && Input.GetKey(KeyCode.W))
        {
            rigidbody2d.velocity = new Vector2(rigidbody2d.velocity.x, Vector2.up.y * jumpVelocity);
            this.gameObject.GetComponent<Transform>().localRotation = new Quaternion(0f, 0f, 0f, 0f);
            this.gameObject.GetComponent<Animator>().Play("JumpLeft");
        }
    }

    private bool IsGrounded()
    {
        RaycastHit2D raycastHit2d = Physics2D.BoxCast(boxCollider2d.bounds.center, boxCollider2d.bounds.size, 0f, Vector2.down, .1f, platformsLayerMask);
        return raycastHit2d.collider != null;
    }
}
