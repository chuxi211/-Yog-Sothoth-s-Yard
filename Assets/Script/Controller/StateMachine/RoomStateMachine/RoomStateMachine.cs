using Data.RunningHotel;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace RoomState
{
    public class RoomStateMachine
    {
        private Dictionary<Type, RoomState> states = new();
        public RoomState currentState { get; private set; }
        private Stack<RoomState> StateStack = new Stack<RoomState>();
        public RoomRunning roomRunning { get; private set; }
        public RoomStateMachine(RoomRunning roomRunning)
        {
            this.roomRunning = roomRunning;
        }
        public void ChangeState<T>() where T : RoomState
        {
            currentState?.Exit();
            currentState = states[typeof(T)];
            currentState?.Enter();
        }
        public void PushState(RoomState newState)
        {
            if (currentState != null)
            {
                StateStack.Push(currentState);
                currentState.Exit();
            }
            currentState = newState;
            currentState?.Enter();
        }
        public void PopState()
        {
            currentState?.Exit();
            currentState=StateStack.Pop();
            currentState?.Enter();
        }
        public void RegisterState(RoomState state)
        {
            states[state.GetType()] = state;
        }
    }
}