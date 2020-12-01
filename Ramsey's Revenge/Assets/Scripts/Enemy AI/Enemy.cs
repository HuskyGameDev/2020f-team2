using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private int health = 100;
    private int damage = 25;
    private GameObject player;

    private void Start()
    {
        //player = FindObjectOfType<PlayerAttacking>();
    }

    private void Update()
    {
        if (player.transform.position.magnitude < 1)
        {
            StartCoroutine(attackPlayer());
        }
    }

    private IEnumerator attackPlayer()
    {
        //will play the animation and damage player
        playAttackAnimation();
        yield return new WaitForSeconds(3);
        damagePlayer();
        yield return new WaitForSeconds(2);
    }

    private void damagePlayer()
    {
        //player.GetComponent<PlayerAttacking>().takeDamage(damage);
    }

    public void takeDamage(int damageTaken)
    {
        health -= damageTaken;
    }

    private void playAttackAnimation()
    {
        this.gameObject.GetComponent<Animator>().Play("Attack");
    }
}
