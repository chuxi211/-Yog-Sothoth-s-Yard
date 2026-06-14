using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace CoreState
{
    public class ExitState : CoreState
    {
        public ExitState(CoreStateMachine stateMachine) : base(stateMachine)
        {
        }

        public override void Enter()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#endif
            Application.Quit();
        }
    }
}