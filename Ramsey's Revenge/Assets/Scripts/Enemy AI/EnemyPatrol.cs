using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{

    public float speed;
    private float waitTime;
    public float startWaitTime;
    public int health;
    public GameObject player;
    public Sprite explode;
    public SpriteRenderer spriteRenderer;

    public Transform[] moveSpots;
    private int randomSpot;
    private int damage;
    private bool exploded;

    // Start is called before the first frame update
    void Start()
    {
        waitTime = startWaitTime;
        randomSpot = Random.Range(0, moveSpots.Length);
        damage = 25;
        exploded = false;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, moveSpots[randomSpot].position, speed * Time.deltaTime);
        //Debug.Log(Vector2.Distance(transform.position, moveSpots[randomSpot].position));

        if (Vector2.Distance(transform.position, moveSpots[randomSpot].position) < 2.0f && !exploded)
        {
            if(waitTime <= 0)
            {
                randomSpot = Random.Range(0, moveSpots.Length);
                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
        if (exploded)
        {
            if (waitTime <= 0)
            {
                Destroy(gameObject);
            }
            else
            {
                waitTime -= Time.deltaTime*2;
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.name == "Player" && !exploded)
        {
            FindObjectOfType<AudioManager>().PlaySound("Explosion");
            player.GetComponent<PlayerHealth>().SendMessage("PlayerTakesDamage", damage);
            spriteRenderer.sprite = explode;
            transform.position = new Vector2(transform.position.x, transform.position.y + 1);
            exploded = true;
        }
    }

    public void TakeDamage(int damageTaken)
    {
        health -= damageTaken;
        //this.gameObject.GetComponent<Animator>().Play("DamageTaken");
        if (health <= 0)
            Destroy(gameObject);
    }
}
