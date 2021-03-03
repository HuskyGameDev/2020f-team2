using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    DialogeManager manager;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.name == "Player")
        {
            //FindObjectOfType<DialogeManager>().StartDialogue(dialogue);
            manager = new DialogeManager();
            manager.StartDialogue(dialogue);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
           // FindObjectOfType<DialogeManager>().StartDialogue(dialogue);
        }
    }
}
