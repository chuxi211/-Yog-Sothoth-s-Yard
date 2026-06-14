using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ManagementState
{
    public class AnimationState : ManagementState
    {
        private AnimRequest request;
        private CanvasGroup canvasGroup;
        public AnimationState(ManagementStateMachine managementStateMachine, AnimRequest request) : base(managementStateMachine)
        {
            this.request = request;
        }

        public override void Enter()
        {
            Debug.Log($"CurrentState : {nameof(AnimationState)}");
            EventBus.Subscribe<AnimationEndedEvent>(ToPrevState);
            canvasGroup=GameObject.Find("Animations").GetComponent<CanvasGroup>();
            canvasGroup.alpha = 1;
            Debug.Log("CurrentState:AnimationState,Try Play Animation");
            StateMachine.managementContext.animationSystem.Play(request);
        }
        public override void Exit()
        {
            canvasGroup.alpha = 0;
            EventBus.UnSubscribe<AnimationEndedEvent>(ToPrevState);
        }
        private void ToPrevState(AnimationEndedEvent e)
        {
            StateMachine.PopState();
        }
    }
}