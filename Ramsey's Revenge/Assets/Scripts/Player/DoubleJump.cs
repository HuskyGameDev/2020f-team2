using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleJump : MonoBehaviour
{
    public PlayerMovement player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        player.doubleJump = true;
        this.GetComponent<SpriteRenderer>().enabled = false;
    }
}
