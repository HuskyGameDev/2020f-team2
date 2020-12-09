using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private int health = 100;
    private int damage = 25;
    private PlayerHealth player;
    private bool attacking = false;
    private Vector3 lastLocation;

    private void Start()
    {
        player = FindObjectOfType<PlayerHealth>();
    }

    private void Update()
    {
        float distanceToPlayer = Vector3.Distance(player.transform.position, gameObject.transform.position);
        if (distanceToPlayer < 25 && !attacking)
        {
            attacking = true;
            StartCoroutine(attackPlayer());
        }

        if(distanceToPlayer < 300)
        {
            lastLocation = gameObject.transform.position;
        } else
        {
            gameObject.transform.position = lastLocation;
        }
    }

    private IEnumerator attackPlayer()
    {
        //will play the animation and damage player
        //gameObject.GetComponent<Animator>().Play("Attack");
        player.playerTakesDamage(damage);
        yield return new WaitForSeconds(3f);
        attacking = false;
    }

    public void takeDamage(int damageTaken)
    {
        health -= damageTaken;
        this.gameObject.GetComponent<Animator>().Play("DamageTaken");
        Debug.Log("hello");
        if (health <= 0)
            Destroy(gameObject);
    }
}
