using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public int time;
    public float speed;

    private Transform target;
    private GameObject player;

    private int count;
    private int damage;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        player = GameObject.FindGameObjectWithTag("Player");

        count = 0;
        damage = 5;
    }

    // Update is called once per frame
    void Update()
    {
        if (count == 0)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            if (target.position.x < transform.position.x)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(-50, target.position.y);
            }
            else
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(50, target.position.y);
            }

        }
        count++;
        if (count == time)//Gets rid of the spit after a certain amount of time
        {
            Destroy(gameObject);
        }
    }
    //private IEnumerator AttackPlayer()
    //{
    //    Debug.Log(player);
    //    player.GetComponent<PlayerHealth>().SendMessage("PlayerTakesDamage", damage);
    //    yield return new WaitForSeconds(3f);
    //}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == player)
        {
            player.GetComponent<PlayerHealth>().SendMessage("PlayerTakesDamage", damage);
        }
        //Destroy(gameObject);
    }
}
