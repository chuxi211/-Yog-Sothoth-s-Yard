using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace CoreState
{
    public abstract class CoreState
    {
        protected CoreStateMachine stateMachine;
        public CoreState(CoreStateMachine stateMachine)
        {
            this.stateMachine = stateMachine;
        }

        public abstract void Enter();
        public virtual void Exit() { }
        public virtual void Update() { }
    }
}
