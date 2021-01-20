using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttacking : MonoBehaviour
{
    private bool attacking = false;

    private float attackTimer = 0f;
    private float attackCd = 0.5f;

    public Collider2D attackTrigger;
    private Rigidbody2D rigidbody2d;

    private void Awake()
    {
        attackTrigger.enabled = false;
        rigidbody2d = transform.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !attacking)
        {
            attacking = true;
            attackTimer = attackCd;

            attackTrigger.enabled = true;
        }

        if (attacking)
        {
            if (attackTimer > 0)
            {
                attackTimer -= Time.deltaTime;
            }
            else
            {
                attacking = false;
                attackTrigger.enabled = false;
                this.GetComponent<Animator>().Play("Idle");
            }
        }
    }
}
