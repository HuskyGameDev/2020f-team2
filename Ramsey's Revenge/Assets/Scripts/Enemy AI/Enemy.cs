using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private int health;
    private int damage = 25;
    public GameObject player;
    private bool attacking = false;
    private Vector3 lastLocation;
    private Rigidbody2D play;
    private SpriteRenderer sprite;
    public GameObject heart;

    private void Start()
    {
        //player = FindObjectOfType<PlayerHealth>();
        health = 100;
        lastLocation = gameObject.transform.position;
        play = FindObjectOfType<Rigidbody2D>();
        sprite = GameObject.FindGameObjectWithTag("Enemy").GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        float distanceToPlayer = Vector3.Distance(player.transform.position, gameObject.transform.position);
        
        if (distanceToPlayer < 25 && !attacking && !player.GetComponent<PlayerMovement>().ram)
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
        if (player.transform.position.x > transform.position.x)
        {
            this.gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }
        else
        {
            this.gameObject.GetComponent<SpriteRenderer>().flipX = false;
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
        StartCoroutine(bounce());
        health -= damageTaken;
        this.gameObject.GetComponent<Animator>().Play("DamageTaken");
        if (health <= 0)
        {
            System.Random rand = new System.Random();
            if(rand.Next(0, 10) > 7)
            {
                GameObject newHeart;
                newHeart = Instantiate(heart, this.transform.position, this.transform.rotation);
                newHeart.GetComponent<SpriteRenderer>().enabled = true;
            }

            StartCoroutine(destroyEnemy());
        }
    }

    private IEnumerator bounce()
    {
        this.GetComponent<BoxCollider2D>().isTrigger = false;
        yield return new WaitForSeconds(0.5f);
        this.GetComponent<BoxCollider2D>().isTrigger = true;
    }

    private IEnumerator destroyEnemy()
    {
        yield return new WaitForSeconds(0.1f);
        Destroy(gameObject);
    }
}
