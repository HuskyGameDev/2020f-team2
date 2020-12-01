using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderState : BaseState
{
    private Enemy enemy;

    [SerializeField] GameObject wanderArea;
    private Vector3 destination;

    public WanderState(Enemy enemy) : base(enemy.gameObject)
    {
        this.enemy = enemy;
    }

    public override Type Tick()
    {
        if (destination == null)
            FindRandomDestination();
        return null;
    }

    private void FindRandomDestination()
    {
        // This part is a VERY rough draft
        Vector3 wanderAreaVector = wanderArea.transform.position;
        Vector3 newDestination = new Vector3(UnityEngine.Random.Range(wanderAreaVector.x - (wanderArea.transform.localScale.x * wanderAreaVector.x)/2, wanderAreaVector.x + (wanderArea.transform.localScale.x * wanderAreaVector.x) / 2),
                                             UnityEngine.Random.Range(wanderAreaVector.y - (wanderArea.transform.localScale.y * wanderAreaVector.y) / 2, wanderAreaVector.y + (wanderArea.transform.localScale.y * wanderAreaVector.y) / 2));
    }
}
