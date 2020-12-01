using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderState : BaseState
{
    private Vector3? destination;
    private float stopDistance = 1f;
    private float _rayDistance = 3.5f;
    private Vector3 direction;
    private Enemy enemy;


    public WanderState(Enemy enemy) : base(enemy.gameObject)
    {
        this.enemy = enemy;
    }

    public override Type Tick()
    {
        var chaseTargert = CheckForAggro();
        
        if (chaseTargert != null)
        {
            enemy.SetTarget(chaseTargert);
            return typeof(ChaseState);
        }


        if (destination.HasValue == false ||
            Vector3.Distance(transform.position, destination.Value) <= stopDistance)
        {
            FindRandomDestination();
        }
        return null;
    }

    private void FindRandomDestination()
    {
        
    }
}
