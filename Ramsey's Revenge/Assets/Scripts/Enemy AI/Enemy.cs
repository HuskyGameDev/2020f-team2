using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private int health = 100;
    private int damage = 25;
    public GameObject player;
    private bool attacking = false;
    private Vector3 lastLocation;

    private void Start()
    {
        //player = FindObjectOfType<PlayerHealth>();
        lastLocation = gameObject.transform.position;
    }

    private void Update()
    {
        float distanceToPlayer = Vector3.Distance(player.transform.position, gameObject.transform.position);
        if (distanceToPlayer < 25 && !attacking)
        {
            attacking = true;
            Debug.Log("Enemy attack");
            StartCoroutine(AttackPlayer());
        }

        if(distanceToPlayer < 300)
        {
            this.gameObject.GetComponent<Pathfinding.AIPath>().canSearch = true;
            lastLocation = gameObject.transform.position;
        } else
        {
            gameObject.transform.position = lastLocation;
            this.gameObject.GetComponent<Pathfinding.AIPath>().canSearch = false;
        }
    }

    private IEnumerator AttackPlayer()
    {
        //will play the animation and damage player
        //gameObject.GetComponent<Animator>().Play("Attack");
        player.GetComponent<PlayerHealth>().SendMessage("PlayerTakesDamage", damage);
        yield return new WaitForSeconds(3f);
        attacking = false;
    }

    public void TakeDamage(int damageTaken)
    {
        health -= damageTaken;
        this.gameObject.GetComponent<Animator>().Play("DamageTaken");
        if (health <= 0)
            Destroy(gameObject);
    }
}
