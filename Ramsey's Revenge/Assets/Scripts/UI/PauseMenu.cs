using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    private bool isPaused;
    public GameObject menu;
    public GameObject player;
    private int numEnemies;
    private Pathfinding.AIPath[] enemies;
    public bool canPause;
    private Vector2 savedVelocity;

    // Start is called before the first frame update
    void Start()
    {
        isPaused = false;
        canPause = true;
    }

    // Update is called once per frame
    void Update()
    {
        // Code for pausing
        if (Input.GetKeyDown(KeyCode.P) && !isPaused && canPause)
        {
            if (GameMusic.isMenuMusic != true)
            {
                GameObject.FindGameObjectWithTag("Music").GetComponent<GameMusic>().StopMusic();
                GameObject.FindGameObjectWithTag("Music").GetComponent<GameMusic>().PlayMenuMusic();
            }
            menu.SetActive(true);
            isPaused = true;
            player.GetComponent<PlayerMovement>().canMove = false;
            savedVelocity = player.GetComponent<Rigidbody2D>().velocity;
            player.GetComponent<Rigidbody2D>().simulated = false;
            FindObjectOfType<BigEnemy>().StopAllCoroutines();
            FindObjectOfType<BigEnemy>().canMove = false;
            enemies = FindObjectsOfType<Pathfinding.AIPath>();
            numEnemies = FindObjectsOfType<Pathfinding.AIPath>().Length;
            int i;
            for(i = 0; i < numEnemies; i++)
            {
                enemies[i].canMove = false;
            }
        }
        // Code for unpausing
        else if(Input.GetKeyDown(KeyCode.P) && isPaused)
        {
            unPause();
        }
    }

    // Code for unpausing continued. Can be used by resume button.
    public void unPause()
    {
        if (GameMusic.isLevelMusic != true)
        {
            GameObject.FindGameObjectWithTag("Music").GetComponent<GameMusic>().StopMusic();
            GameObject.FindGameObjectWithTag("Music").GetComponent<GameMusic>().PlayLevelMusic();
        }
        menu.SetActive(false);
        isPaused = false;
        player.GetComponent<PlayerMovement>().canMove = true;
        player.GetComponent<Rigidbody2D>().simulated = true;
        player.GetComponent<Rigidbody2D>().velocity = savedVelocity;
        FindObjectOfType<BigEnemy>().canMove = true;
        enemies = FindObjectsOfType<Pathfinding.AIPath>();
        numEnemies = FindObjectsOfType<Pathfinding.AIPath>().Length;
        int i;
        for (i = 0; i < numEnemies; i++)
        {
            enemies[i].canMove = true;
        }
    }
}
