using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    public int health;
    private bool ram = false;
    public Collider2D col;

    // Start is called before the first frame update
    void Start()
    {
        health = 100; // default health
    }

    // Update is called once per frame
    void Update()
    {
        //checks for death
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    //can be called by enemies
    public void playerTakesDamage(int damage)
    {
        if (!col.enabled)
        {
            health -= damage;
            this.gameObject.GetComponent<Animator>().Play("DamageTaken");
        }
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
