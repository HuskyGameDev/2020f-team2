using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int health;
    public int numOfHearts;
    public float[] position;

    public PlayerData(PlayerHealth player)
    {
        health = player.health;
        numOfHearts = player.numOfHearts;

        Transform play = GameObject.FindGameObjectWithTag("Player").transform;

        position = new float[3];
        position[0] = play.transform.position.x;
        position[1] = play.transform.position.y;
        position[2] = play.transform.position.z;
    }
}
