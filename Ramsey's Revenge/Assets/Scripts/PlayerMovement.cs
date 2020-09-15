using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public LayerMask platformsLayerMask;
    private Rigidbody2D rigidbody2d;
    private BoxCollider2D boxCollider2d;
    public float moveSpeed;
    public float jumpVelocity;

    private void Start()
    {
        rigidbody2d = transform.GetComponent<Rigidbody2D>();
        boxCollider2d = transform.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        // Jump Code
        if (IsGrounded() && Input.GetKeyDown(KeyCode.W))
        {
            rigidbody2d.velocity = Vector2.up * jumpVelocity;
        }

        // Walk Code
        if (Input.GetKey(KeyCode.A))
        {
            Vector3 position = transform.position;
            position.x -= moveSpeed * Time.deltaTime;
            transform.position = position;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            Vector3 position = transform.position;
            position.x += moveSpeed * Time.deltaTime;
            transform.position = position;
        }
    }

    private bool IsGrounded()
    {
        RaycastHit2D raycastHit2d = Physics2D.BoxCast(boxCollider2d.bounds.center, boxCollider2d.bounds.size, 0f, Vector2.down, .1f, platformsLayerMask);
        return raycastHit2d.collider != null;
    }
}
