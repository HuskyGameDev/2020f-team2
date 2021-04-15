using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseHealth : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerHealth>().numOfHearts += 1;
            int hearts = collision.GetComponent<PlayerHealth>().numOfHearts;
            collision.GetComponent<PlayerHealth>().health = hearts * 25;
            Destroy(gameObject);
        }
    }
}
