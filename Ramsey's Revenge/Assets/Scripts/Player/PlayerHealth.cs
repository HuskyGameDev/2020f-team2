using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    public int health;
    //private bool ram = false;

    // Start is called before the first frame update
    void Start()
    {
        health = 100; // default health
    }

    // Update is called once per frame
    void Update()
    {
        //checks for death
        //if (health <= 0)
        //{
        //    Destroy(gameObject);
        //}
        if (health <= 0)
        {
            gameObject.transform.position = new Vector3(-155, 40, 0);
            Debug.Log("You died!!");
            health = 100;
        }
    }

    //can be called by enemies
    public void PlayerTakesDamage(int damage)
    {
        health -= damage;
        this.gameObject.GetComponent<Animator>().Play("DamageTaken");
    }
}
