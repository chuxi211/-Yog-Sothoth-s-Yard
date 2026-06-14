using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace CoreState { 

public class InitState : CoreState
{
    public InitState(CoreStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        Debug.Log("Current : InitState");
        stateMachine.ChangeState<HomeState>();
    }
    public override void Exit()
    {
        Debug.Log("Exit : InitState");
    }
}
}