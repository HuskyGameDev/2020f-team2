using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    private Dictionary<Type, BaseState> _availabeStates;

    public BaseState CurrentState { get; private set; }
    public event Action<BaseState> OnStateChanged;

    public void SetStates(Dictionary<Type, BaseState> states)
    {
        _availabeStates = states;
    }

    private void Update()
    {
        if (CurrentState == null)
        {
            CurrentState = _availabeStates.Values.First();
        }

        var nextState = CurrentState?.Tick();

        if (nextState != null && nextState != CurrentState?.GetType())
        {
            SwitchToNewState(nextState);
        }
    }

    private void SwitchToNewState(Type nextState)
    {
        CurrentState = _availabeStates[nextState];
        OnStateChanged?.Invoke(CurrentState);
    }
}
