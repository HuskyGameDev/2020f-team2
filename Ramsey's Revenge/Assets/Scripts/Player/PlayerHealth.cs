using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    public int health;

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
    public void takeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
