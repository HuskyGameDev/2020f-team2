using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigPiggyAttack : MonoBehaviour
{
    private bool attacking = false;
    private float damage = 50f;
    private BigEnemy parent;

    private void Start()
    {
        parent = FindObjectOfType<BigEnemy>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player") && !parent.turning && !attacking)
        {
            StartCoroutine(AttackPlayer(col));
        }
    }

    private IEnumerator AttackPlayer(Collider2D player)
    {
        //will play the animation and damage player
        attacking = true;
        parent.canMove = false;
        player.GetComponent<PlayerHealth>().SendMessage("PlayerTakesDamage", damage);
        this.GetComponentInParent<Animator>().Play("Attack");
        yield return new WaitForSeconds(1f);
        attacking = false;
        parent.canMove = true;
    }

    private IEnumerator bounce()
    {
        this.GetComponent<BoxCollider2D>().isTrigger = false;
        yield return new WaitForSeconds(0.5f);
        this.GetComponent<BoxCollider2D>().isTrigger = true;
    }
}
