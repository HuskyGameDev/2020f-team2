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
    private BigEnemy bigEnemy;

    // Start is called before the first frame update
    void Start()
    {
        isPaused = false;
        canPause = true;
        bigEnemy = FindObjectOfType<BigEnemy>();
    }

    // Update is called once per frame
    void Update()
    {
        // Code for pausing
        if (Input.GetKeyDown(KeyCode.P) && !isPaused && canPause)
        {
            menu.SetActive(true);
            isPaused = true;
            player.GetComponent<PlayerMovement>().canMove = false;
            savedVelocity = player.GetComponent<Rigidbody2D>().velocity;
            player.GetComponent<Rigidbody2D>().simulated = false;
            bigEnemy.StopAllCoroutines();
            bigEnemy.canMove = false;
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
        menu.SetActive(false);
        isPaused = false;
        player.GetComponent<PlayerMovement>().canMove = true;
        player.GetComponent<Rigidbody2D>().simulated = true;
        player.GetComponent<Rigidbody2D>().velocity = savedVelocity;
        bigEnemy.canMove = true;
        bigEnemy.turning = false;
        enemies = FindObjectsOfType<Pathfinding.AIPath>();
        numEnemies = FindObjectsOfType<Pathfinding.AIPath>().Length;
        int i;
        for (i = 0; i < numEnemies; i++)
        {
            enemies[i].canMove = true;
        }
    }
}
