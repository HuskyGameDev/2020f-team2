using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEdgePatrol : MonoBehaviour
{

    public float speed;
    public int health;
    public GameObject player;

    private bool movingRight = true;

    public Transform groundDetection;

    private int damage;

    // Start is called before the first frame update
    void Start()
    {
        damage = 5;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);

        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, 2f);
        if(groundInfo.collider == false)
        {
            if(movingRight == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;
            }
        }
    }
    public void TakeDamage(int damageTaken)
    {
        health -= damageTaken;
        //this.gameObject.GetComponent<Animator>().Play("DamageTaken");
        if (health <= 0)
            Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.name == "Player")
        {
            player.GetComponent<PlayerHealth>().SendMessage("PlayerTakesDamage", damage);
            transform.position = new Vector2(transform.position.x, transform.position.y + 1);
        }
    }
}
