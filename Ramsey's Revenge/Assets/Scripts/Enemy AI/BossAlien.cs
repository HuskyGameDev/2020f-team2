using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAlien : MonoBehaviour
{
    public int speed;
    public int health;
    public Transform mothership;
    public GameObject player;
    public GameObject danger;

    private bool movingRight;
    private bool waiting;

    // Start is called before the first frame update
    void Start()
    {
        movingRight = true;
        waiting = true;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);//Get the enemy moving
        //Debug.Log(Vector2.Distance(transform.position, player.transform.position));
        if (Vector2.Distance(transform.position, player.transform.position) < 10f)//Chase the player they got too close
        {
            if (player.transform.position.x > transform.position.x)//Chase the player to the right
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;
            }
            else//Chase the player to the left
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingRight = false;
            }
        }
        else
        {
            if (Vector2.Distance(transform.position, mothership.position) > 10f)//Keeps enemy in a certain range
            {
                if (movingRight == true)
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
            if (Vector2.Distance(transform.position, mothership.position) > 10.1f)//Chased player too far? No problem, enemy will be teleported back home
            {
                transform.position = mothership.position;
            }
        }
        if (Vector2.Distance(transform.position, player.transform.position) < 10f)
        {
            Vector2 start = new Vector2(transform.position.x, transform.position.y + 1);
            //Instantiate(danger, start, Quaternion.identity);
            if (waiting)
            {
                StartCoroutine(SpitAttack(0.5f));
            }
        }
    }
    public void TakeDamage(int damageTaken)//Allows Ramsey to kill the enemy
    {
        health -= damageTaken;
        if (health <= 0)
        {
            BossWalls[] walls = FindObjectsOfType<BossWalls>();
            walls[0].endFight();
            walls[1].endFight();
            Destroy(gameObject);
        }
    }
    private IEnumerator SpitAttack(float time)
    {
        waiting = false;
        yield return new WaitForSeconds(time);
        waiting = true;
        Vector2 start = new Vector2(transform.position.x, transform.position.y + 1);
        Instantiate(danger, start, Quaternion.identity);
    }
}
