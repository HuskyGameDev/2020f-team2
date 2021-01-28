using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    public int health;
    public GameObject playerCamera;
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
            gameObject.transform.position = new Vector3(-155f, 40f, 0f);
            playerCamera.transform.position = new Vector3(-80.9f, 103.2f, -1f);
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
