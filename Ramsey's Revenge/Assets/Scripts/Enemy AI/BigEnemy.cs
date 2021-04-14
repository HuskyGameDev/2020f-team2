using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigEnemy : MonoBehaviour
{
    public int health;
    public GameObject player;
    private bool facingRight = true;
    public bool turning = false;
    public bool canMove = true;
    public GameObject Position1;
    public GameObject Position2;
    public float speed;
    public GameObject wall1;
    public GameObject wall2;

    private void Start()
    {

    }

    private void Update()
    {
        float distanceToPlayer = Vector3.Distance(player.transform.position, gameObject.transform.position);

        if (distanceToPlayer < 300)
        {
            if (player.transform.position.x > transform.position.x && !facingRight && !turning)
            {
                StartCoroutine(SlowTurn());
            }
            else if (player.transform.position.x < transform.position.x && facingRight && !turning)
            {
                StartCoroutine(SlowTurn());
            }

            if (canMove)
            {
                if (facingRight)
                {
                    transform.position = new Vector2(transform.position.x + speed, transform.position.y);
                    this.GetComponent<Animator>().Play("Walk");
                }
                else
                {
                    transform.position = new Vector2(transform.position.x - speed, transform.position.y);
                    this.GetComponent<Animator>().Play("Walk");
                }
            }
        }
        else
        {
            if (facingRight && canMove)
            {
                transform.position = new Vector2(transform.position.x + speed, transform.position.y);
                this.GetComponent<Animator>().Play("Walk");
                if (this.GetComponent<BoxCollider2D>().IsTouching(Position2.GetComponent<BoxCollider2D>()))
                {
                    StartCoroutine(SlowTurn());
                }
            }
            else if (canMove)
            {
                transform.position = new Vector2(transform.position.x - speed, transform.position.y);
                this.GetComponent<Animator>().Play("Walk");
                if (this.GetComponent<BoxCollider2D>().IsTouching(Position1.GetComponent<BoxCollider2D>()))
                {
                    StartCoroutine(SlowTurn());
                }
            }
        }
    }

    private void Flip()
    {
        facingRight = !facingRight;

        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    private IEnumerator SlowTurn()
    {
        turning = true;
        canMove = false;
        this.GetComponent<Animator>().Play("Idle");
        yield return new WaitForSeconds(2f);
        turning = false;
        Flip();
        canMove = true;
    }

    public void TakeDamage(int damageTaken)
    {
        health -= damageTaken;
        this.gameObject.GetComponent<Animator>().Play("DamageTaken");
        if (health <= 0)
        {
            wall1.SendMessage("endFight");
            wall2.SendMessage("endFight");
            Destroy(gameObject);
        }
    }
}
