using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public LayerMask platformsLayerMask;
    private Rigidbody2D rigidbody2d;
    private BoxCollider2D boxCollider2d;
    public GameObject child;
    public float moveSpeed = 80f;
    public float jumpVelocity = 200f;
    private float movement;
    private float gravity;
    public Sprite left;
    public Sprite right;
    private int direction = 0;
    public bool doubleJump;
    private bool canDoubleJump;

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

        // To stop sliding on hills
        if (IsGrounded())
        {
            rigidbody2d.gravityScale = 0f;
            rigidbody2d.velocity = new Vector2(rigidbody2d.velocity.x / 2, rigidbody2d.velocity.y);
        }
        else
        {
            rigidbody2d.gravityScale = gravity;
        }

        if (doubleJump)
        {
            if (IsGrounded())
            {
                canDoubleJump = true;
            }
        }

        if (Input.GetKey(KeyCode.A))
        {
            rigidbody2d.velocity = new Vector2(Vector2.left.x * moveSpeed, rigidbody2d.velocity.y);
            if (IsGrounded())
            {
                this.gameObject.GetComponent<Animator>().enabled = true;
                this.gameObject.GetComponent<Animator>().Play("MoveLeft");
            }
            else
            {
                this.gameObject.GetComponent<SpriteRenderer>().sprite = left;
            }
            direction = 1;
            child.transform.localPosition = new Vector3(-10f, child.transform.localPosition.y);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            rigidbody2d.velocity = new Vector2(Vector2.right.x * moveSpeed, rigidbody2d.velocity.y);
            if (IsGrounded())
            {
                this.gameObject.GetComponent<Animator>().enabled = true;
                this.gameObject.GetComponent<Animator>().Play("MoveRight");
            }
            else
            {
                this.gameObject.GetComponent<SpriteRenderer>().sprite = right;
            }
            direction = 0;
            child.transform.localPosition = new Vector3(10f, child.transform.localPosition.y);
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
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (IsGrounded())
            {
                rigidbody2d.velocity = new Vector2(rigidbody2d.velocity.x, Vector2.up.y * jumpVelocity);
            }
            else
            {
                if (canDoubleJump)
                {
                    rigidbody2d.velocity = new Vector2(rigidbody2d.velocity.x, Vector2.up.y * jumpVelocity);
                    canDoubleJump = false;
                }
            }

            this.gameObject.GetComponent<Animator>().enabled = true;
            if (direction == 1)
            {
                this.gameObject.GetComponent<Animator>().Play("JumpLeft");
            }
            else if (direction == 0)
            {
                this.gameObject.GetComponent<Animator>().Play("JumpRight");
            }
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            if (rigidbody2d.velocity.y > 0)
            {
                rigidbody2d.velocity = new Vector2(rigidbody2d.velocity.x, rigidbody2d.velocity.y * .5f);
            }

            this.gameObject.GetComponent<Animator>().enabled = false;
            if (direction == 1)
            {
                this.gameObject.GetComponent<SpriteRenderer>().sprite = left;
            }
            else if (direction == 0)
            {
                this.gameObject.GetComponent<SpriteRenderer>().sprite = right;
            }
        }
    }

    private bool IsGrounded()
    {
        RaycastHit2D raycastHit2d = Physics2D.BoxCast(boxCollider2d.bounds.center, boxCollider2d.bounds.size, 0f, Vector2.down, .1f, platformsLayerMask);
        return raycastHit2d.collider != null;
    }
}
