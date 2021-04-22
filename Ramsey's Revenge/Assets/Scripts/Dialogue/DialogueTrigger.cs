using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    DialogeManager manager;
    public GameObject dialogeBox;
    public Sprite dialogueImageToBe;
    Image dialogueImage;
    public Collider2D dialogueCollider;
    public Text textBox;
    public GameObject Ramsey;
    public GameObject Enemy;
    int currentSentence = 0;
    public float timeRemaining = 10;

    bool dialogueWasTriggered = false;

    private void Start()
    {
        dialogueImage = dialogeBox.GetComponents<Image>()[0];
    }
    private void Update()
    {
        if (dialogueWasTriggered == true && Input.GetKeyDown(KeyCode.Return))
        {

                if (currentSentence < dialogue.sentences.Length - 1)
                {
                    currentSentence++;
                    textBox.text = dialogue.sentences[currentSentence];
                }
                else
                {
                    dialogueImage.color = new Color(0, 0, 0, 0);
                    textBox.text = "";
                    if (Ramsey.transform.GetComponent<PlayerMovement>() != null)
                    {
                        Ramsey.transform.GetComponent<PlayerMovement>().canMove = true;
                    }
                    if (Enemy.transform.GetComponent<Enemy>() != null)
                    {
                        Enemy.GetComponent<Pathfinding.AIPath>().canMove = true;
                    }
                    FindObjectOfType<PauseMenu>().canPause = true;
                }
            }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.name == "Player")
        {
            dialogueWasTriggered = true;
            FindObjectOfType<PauseMenu>().canPause = false;
            if (Enemy.transform.GetComponent<Enemy>() != null)
            {
                Enemy.GetComponent<Pathfinding.AIPath>().canMove = false;
            }
            if (Ramsey.transform.GetComponent<PlayerMovement>() != null)
            {
                //collider.transform.parent.GetComponent<PlayerMovement>().canMove = false;

                Ramsey.transform.GetComponent<PlayerMovement>().canMove = false;
                Ramsey.GetComponent<Animator>().Play("Idle");
            }
            //FindObjectOfType<DialogeManager>().StartDialogue(dialogue);
            manager = new DialogeManager();
            manager.StartDialogue(dialogue);
            dialogueImage.sprite = dialogueImageToBe;
            dialogueImage.rectTransform.sizeDelta = new Vector2(800, 100);
            dialogueImage.color = new Color(255, 255, 255, 1);

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

    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);

        // Code to execute after the delay
    }

}
