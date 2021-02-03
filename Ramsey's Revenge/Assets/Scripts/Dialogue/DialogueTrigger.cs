using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.name == "Player")
        {
            FindObjectOfType<DialogeManager>().StartDialogue(dialogue);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            FindObjectOfType<DialogeManager>().StartDialogue(dialogue);
        }
    }
}
