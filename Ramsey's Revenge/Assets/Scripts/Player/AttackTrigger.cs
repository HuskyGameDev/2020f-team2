using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTrigger : MonoBehaviour
{
    public int dmg = 50;

    private void OnTriggerEnter2D(Collider2D col)
    {
        // Sends the collision message to the enemy code
        if (col.isTrigger == true && col.CompareTag("Enemy"))
        {
            col.SendMessageUpwards("TakeDamage", dmg);
        }
    }

    
}
