using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ManagementState { 
    public class ManagementStateMachine
    {
        private ManagementState currentState;
        private Stack<ManagementState> StateStack=new();
        public ManagementContext managementContext { get; private set; }
        private Dictionary<System.Type, ManagementState> states=new();
        public ManagementStateMachine()
        {
            managementContext = new ManagementContext();
        }
        public void RegisterState(ManagementState state)
        {
            states[state.GetType()] = state;
        }
        public void ChangeState<T>(object data=null) where T:ManagementState 
        {
            currentState?.Exit();
            currentState = states[typeof(T)];
            currentState?.Enter();
        }
        public void PushState(ManagementState state)
        {
            if (currentState != null)
            {
                StateStack.Push(currentState);
                currentState.Exit();
            }
            currentState = state;
            currentState?.Enter();
        }
        public void PopState()
        {
            currentState?.Exit();
            currentState=StateStack.Pop();
            currentState?.Enter();
        }
    }
}

