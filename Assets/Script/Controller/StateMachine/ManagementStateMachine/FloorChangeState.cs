using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ManagementState
{
    public class FloorChangeState : ManagementState
    {
        private CanvasGroup canvasGroup;

        public FloorChangeState(ManagementStateMachine managementStateMachine) : base(managementStateMachine)
        {
        }

        public override void Enter()
        {
            EventBus.Subscribe<CloseFloorChangePanelEvent>(CloseFloorChangePanel);
            canvasGroup=GameObject.Find("FloorChangePanel").GetComponent<CanvasGroup>();
            if (canvasGroup == null)
            {
                return;
            }
            canvasGroup.alpha = 1;
            canvasGroup.interactable=true;
            canvasGroup.blocksRaycasts=true;
        }
        public override void Exit()
        {
            EventBus.UnSubscribe<CloseFloorChangePanelEvent>(CloseFloorChangePanel);
        }
        private void CloseFloorChangePanel(CloseFloorChangePanelEvent e)
        {
            canvasGroup.alpha = 0;
            canvasGroup.interactable = false;
            canvasGroup.blocksRaycasts = false;
            StateMachine.ChangeState<RunningState>();
        }
    }
}