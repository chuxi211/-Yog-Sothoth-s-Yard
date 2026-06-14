using ManagementState;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ManagementState
{
    public class CleanPanelOpenedState : ManagementState
    {
        private CanvasGroup canvasGroup;
        public CleanPanelOpenedState(ManagementStateMachine managementStateMachine) : base(managementStateMachine)
        {
        }

        public override void Enter()
        {
            EventBus.Subscribe<CloseCleanEvent>(CloseCurrentPanel);
            EventBus.Subscribe<MonthSwitchedEvent>(ToLevelEvalutionState);
            EventBus.Subscribe<RequestCleanAnimEvent>(ToAnimationState);
            canvasGroup = GameObject.Find("Clean").GetComponent<CanvasGroup>();
            canvasGroup.interactable = true;
            canvasGroup.blocksRaycasts = true;
            canvasGroup.alpha = 1.0f;
        }
        public override void Exit()
        {
            EventBus.UnSubscribe<CloseCleanEvent>(CloseCurrentPanel);
            EventBus.UnSubscribe<MonthSwitchedEvent>(ToLevelEvalutionState);
            EventBus.UnSubscribe<RequestCleanAnimEvent>(ToAnimationState);
        }
        private void CloseCurrentPanel(CloseCleanEvent e)
        {
            canvasGroup.interactable = false;
            canvasGroup.blocksRaycasts = false;
            canvasGroup.alpha = 0f;
            StateMachine.ChangeState<MainManageState>();
        }
        private void ToLevelEvalutionState(MonthSwitchedEvent e)
        {
            canvasGroup.interactable = false;
            canvasGroup.blocksRaycasts = false;
            canvasGroup.alpha = 0f;
            StateMachine.ChangeState<LevelEvalutionState>();
        }
        private void ToAnimationState(RequestCleanAnimEvent e)
        {
            canvasGroup.interactable = false;
            canvasGroup.blocksRaycasts = false;
            canvasGroup.alpha = 0f;
            StateMachine.PushState(new AnimationState(this.StateMachine,e));
        }
    }
}