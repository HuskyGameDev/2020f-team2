using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTrigger : MonoBehaviour
{
    public int dmg = 50;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.isTrigger != true && col.CompareTag("Enemy"))
        {
            Debug.Log("collision");
            col.SendMessageUpwards("takeDamage", dmg);
        }
    }
}
