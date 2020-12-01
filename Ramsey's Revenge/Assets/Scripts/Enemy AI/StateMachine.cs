using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    private Dictionary<Type, BaseState> _availabeStates;

    public void SetStates(Dictionary<Type, BaseState> states)
    {
        _availabeStates = states;
    }
}
