using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ManagementState {
    public class ForestExploreState : ManagementState
    {
        private CanvasGroup canvasGroup;
        public ForestExploreState(ManagementStateMachine managementStateMachine) : base(managementStateMachine)
        {
        }

        public override void Enter()
        {
            EventBus.Subscribe<CloseForestExploreEvent>(CloseForestExplorePanel);
            canvasGroup=GameObject.Find("Forest").GetComponent<CanvasGroup>();
            if (canvasGroup == null)
            {
                Debug.Log("ForestExplore CanvasGroup is null");
                return;
            }
            canvasGroup.alpha=1f;
            canvasGroup.interactable=true;
            canvasGroup.blocksRaycasts=true;
        }
        public override void Exit()
        {
            EventBus.UnSubscribe<CloseForestExploreEvent>(CloseForestExplorePanel);
        }
        private void CloseForestExplorePanel(CloseForestExploreEvent e)
        {
            canvasGroup.alpha = 0f;
            canvasGroup.interactable=false;
            canvasGroup.blocksRaycasts=false;
            StateMachine.ChangeState<ExplorePanelOpenedState>();
        }
    }
}