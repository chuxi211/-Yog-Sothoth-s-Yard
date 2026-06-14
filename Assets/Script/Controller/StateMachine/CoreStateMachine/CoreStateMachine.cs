using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace CoreState
{
    public class CoreStateMachine
    {
        Dictionary<Type, CoreState> states = new();
        CoreState currentState;
        public void RegisterState(CoreState state)
        {
            states[state.GetType()] = state;
        }
        public void ChangeState<T>() where T : CoreState
        {
            currentState?.Exit();
            currentState = states[typeof(T)];
            currentState?.Enter();
        }
    }
}