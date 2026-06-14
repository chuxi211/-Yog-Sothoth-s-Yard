using Data.RunningHotel;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace RoomState
{
    public abstract class RoomState
    {
        protected RoomStateMachine roomStateMachine;
        protected RoomRunning Room;
        public RoomState(RoomStateMachine roomStateMachine,RoomRunning room)
        {
            this.roomStateMachine = roomStateMachine;
            this.Room = room;
        }
        public abstract void Enter();
        public virtual void Exit() { }
    }
}