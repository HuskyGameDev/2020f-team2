using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    DialogeManager manager;
    [SerializeField]GameObject dialogeBox;
    [SerializeField]Sprite dialogueImageToBe;
    Image dialogueImage;
    [SerializeField]Collider2D dialogueCollider;
    [SerializeField] Text textBox;
    int currentSentence = 0;

    bool dialogueWasTriggered = false;

    private void Start()
    {
        dialogueImage = dialogeBox.GetComponents<Image>()[0];
    }
    private void Update()
    {
        if (dialogueWasTriggered == true && Input.GetKeyDown("r"))
        {
            if (currentSentence < dialogue.sentences.Length-1)
            {
                currentSentence++;
                textBox.text = dialogue.sentences[currentSentence];
            }
            else
            {
                dialogueImage.color = new Color(0, 0, 0, 0);
                textBox.text = "";
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.name == "Player")
        {
            dialogueWasTriggered = true;
            //FindObjectOfType<DialogeManager>().StartDialogue(dialogue);
            manager = new DialogeManager();
            manager.StartDialogue(dialogue);

            
            dialogueImage.sprite = dialogueImageToBe;
            dialogueImage.rectTransform.sizeDelta = new Vector2(800, 100);
            dialogueImage.color = new Color(255, 255, 255,1);

            textBox.text = dialogue.sentences[currentSentence];
            
            Debug.Log("");
            Destroy(dialogueCollider);
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
