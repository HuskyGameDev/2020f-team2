using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveKeys : MonoBehaviour
{
    public PlayerHealth ph;
    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            ph.SavePlayer();
            Debug.Log("SAVE");
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            ph.LoadPlayer();
            Debug.Log("LOAD");
        }
    }
}
