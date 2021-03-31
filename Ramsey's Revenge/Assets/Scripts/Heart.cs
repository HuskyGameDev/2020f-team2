using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
    public GameObject player;
    BoxCollider2D heartCollider;
    BoxCollider2D playerCollider;

    // Start is called before the first frame update
    void Start()
    {
        heartCollider = this.GetComponent<BoxCollider2D>();
        playerCollider = player.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (heartCollider.IsTouching(playerCollider))
        {
            player.SendMessage("heal", 25);
            Destroy(gameObject);
        }
    }
}
