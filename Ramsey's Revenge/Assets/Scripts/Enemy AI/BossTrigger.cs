using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTrigger : MonoBehaviour
{
    public GameObject wall1;
    public GameObject wall2;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        wall1.GetComponent<SpriteRenderer>().enabled = true;
        wall1.GetComponent<BoxCollider2D>().enabled = true;
        wall2.GetComponent<SpriteRenderer>().enabled = true;
        wall2.GetComponent<BoxCollider2D>().enabled = true;
    }
}
