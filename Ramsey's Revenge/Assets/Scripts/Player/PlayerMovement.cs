using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public LayerMask platformsLayerMask;
    private Rigidbody2D rigidbody2d;
    public BoxCollider2D boxCollider2d;
    public float moveSpeed = 80f;
    public float jumpVelocity = 200f;
    private float movement;
    private float gravity;
    public Sprite left;
    public Sprite right;
    private bool facingRight = true;
    public bool doubleJump;
    public bool boomerang = false;
    private bool canDoubleJump;
    private bool ram = false;
    public bool canMove = true;
    private Quaternion defaultRotation;

    private void Start()
    {
        rigidbody2d = transform.GetComponent<Rigidbody2D>();
        gravity = rigidbody2d.gravityScale;
        defaultRotation = transform.rotation;
    }

    // Update is called once per frame
    private void Update()
    {

        movement = Input.GetAxis("Horizontal");

        // To stop sliding on hills
        //if (IsGrounded())
        //{
        //    rigidbody2d.gravityScale = 0f;
        //    rigidbody2d.velocity = new Vector2(rigidbody2d.velocity.x / 2f, rigidbody2d.velocity.y);
        //}
        //else
        //{
        //    rigidbody2d.gravityScale = gravity;
        //}

        if (doubleJump)
        {
            if (IsGrounded())
            {
                canDoubleJump = true;
            }
        }

        // Attack move code
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!ram)
            {
                this.gameObject.GetComponent<Animator>().Play("Ram");
                ram = true;
                StartCoroutine(Ram());
            }
        }

        // Move Code
        if (Input.GetKey(KeyCode.A) && canMove)
        {
            rigidbody2d.velocity = new Vector2(Vector2.left.x * moveSpeed, rigidbody2d.velocity.y);

            if (facingRight)
            {
                Flip();
            }

            if (IsGrounded())
            {
                this.gameObject.GetComponent<Animator>().Play("MoveRight");
            }
            else
            {
                this.gameObject.GetComponent<Animator>().Play("Idle");
            }
        }
        else if (Input.GetKey(KeyCode.D) && canMove)
        {
            rigidbody2d.velocity = new Vector2(Vector2.right.x * moveSpeed, rigidbody2d.velocity.y);

            if (!facingRight)
            {
                Flip();
            }

            if (IsGrounded())
            {
                this.gameObject.GetComponent<Animator>().Play("MoveRight");
            }
            else
            {
                this.gameObject.GetComponent<Animator>().Play("Idle");
            }
        }

        if (Input.GetKeyUp(KeyCode.A) && canMove)
        {
            rigidbody2d.velocity = new Vector2(0f, rigidbody2d.velocity.y);
            this.gameObject.GetComponent<Animator>().Play("Idle");
        }

        if (Input.GetKeyUp(KeyCode.D) && canMove)
        {
            rigidbody2d.velocity = new Vector2(0f, rigidbody2d.velocity.y);
            this.gameObject.GetComponent<Animator>().Play("Idle");
        }

        // Jump Code
        if (Input.GetKeyDown(KeyCode.W) && canMove)
        {
            transform.rotation = defaultRotation;
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

            this.gameObject.GetComponent<Animator>().Play("JumpRight");
        }

        if (Input.GetKeyUp(KeyCode.W) && canMove)
        {
            if (rigidbody2d.velocity.y > 0)
            {
                rigidbody2d.velocity = new Vector2(rigidbody2d.velocity.x, rigidbody2d.velocity.y * .5f);
            }

            this.gameObject.GetComponent<Animator>().Play("Idle");
        }
    }

    private void Flip()
    {
        facingRight = !facingRight;

        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    private IEnumerator Ram()
    {
        canMove = false;
        if (facingRight)
        {
            rigidbody2d.velocity = new Vector2(Vector2.right.x * moveSpeed * 2, rigidbody2d.velocity.y);
        }
        else if (!facingRight)
        {
            rigidbody2d.velocity = new Vector2(Vector2.left.x * moveSpeed * 2, rigidbody2d.velocity.y);
        }
        yield return new WaitForSeconds(0.5f);
        rigidbody2d.velocity = new Vector2(0f, rigidbody2d.velocity.y);
        ram = false;
        canMove = true;
    }

    private bool IsGrounded()
    {
        RaycastHit2D raycastHit2d = Physics2D.BoxCast(boxCollider2d.bounds.center, boxCollider2d.bounds.size, 0f, Vector2.down, .1f, platformsLayerMask);
        return raycastHit2d.collider != null;
    }
}
