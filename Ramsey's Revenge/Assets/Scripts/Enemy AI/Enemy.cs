using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private void InitializeStateMachine()
    {
        var states = new Dictionary<Type, BaseState>() {
            { typeof(WanderState), new WanderState(this) }//,
            //{ typeof(ChaseState), new ChaseState(this) },
            //{ typeof(AttackState), new AttackState(this) }
        };


    }
}
