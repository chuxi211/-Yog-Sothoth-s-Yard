using Data.RunningHotel;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace RoomState
{
    public class UnlockState : RoomState
    {
        public UnlockState(RoomStateMachine roomStateMachine, RoomRunning room) : base(roomStateMachine, room)
        {
        }

        public override void Enter()
        {
            throw new System.NotImplementedException();
        }
    }
}