using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigPiggyAttack : MonoBehaviour
{
    private bool attacking = false;
    private float damage = 50f;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player") && !attacking)
        {
            StartCoroutine(AttackPlayer(col));
        }
    }

    private IEnumerator AttackPlayer(Collider2D player)
    {
        //will play the animation and damage player
        player.GetComponent<PlayerHealth>().SendMessage("PlayerTakesDamage", damage);
        attacking = true;
        yield return new WaitForSeconds(3f);
        attacking = false;
    }

    private IEnumerator bounce()
    {
        this.GetComponent<BoxCollider2D>().isTrigger = false;
        yield return new WaitForSeconds(0.5f);
        this.GetComponent<BoxCollider2D>().isTrigger = true;
    }
}
