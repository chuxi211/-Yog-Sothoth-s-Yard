using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ManagementState
{
    public abstract class ManagementState
    {
        protected ManagementStateMachine StateMachine;
        public ManagementState(ManagementStateMachine managementStateMachine)
        {
            this.StateMachine = managementStateMachine;
        }
        public abstract void Enter();
        public virtual void Exit() { }
    }
}
