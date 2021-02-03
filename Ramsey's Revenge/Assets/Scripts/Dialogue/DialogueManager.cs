using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogeManager : MonoBehaviour
{
    private Queue<string> sentences;
    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialoage)
    {
        Debug.Log("Starting conversation with" + dialoage.name);
    }
}
