using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ManagementState
{
    public class ExplorePanelOpenedState : ManagementState
    {
        private CanvasGroup canvasGroup;
        public ExplorePanelOpenedState(ManagementStateMachine managementStateMachine) : base(managementStateMachine)
        {
        }

        public override void Enter()
        {
            EventBus.Subscribe<CloseExplorePanelEvent>(CloseExplorePanel);
            EventBus.Subscribe<OpenForestExploreEvent>(ToForestExplore);
            canvasGroup = GameObject.Find("Explore").GetComponent<CanvasGroup>();
            if (canvasGroup == null)
            {
                Debug.Log("Explore.CanvasGroup is null");
            }
            canvasGroup.alpha = 1;
            canvasGroup.interactable = true;
            canvasGroup.blocksRaycasts = true;
        }
        public override void Exit()
        {
            canvasGroup.alpha = 0f;
            canvasGroup.interactable = false;
            canvasGroup.blocksRaycasts = false;
            EventBus.UnSubscribe<CloseExplorePanelEvent>(CloseExplorePanel);
            EventBus.UnSubscribe<OpenForestExploreEvent> (ToForestExplore);
        }
        private void CloseExplorePanel(CloseExplorePanelEvent e)
        {
            StateMachine.ChangeState<RunningState>();
        }
        private void ToForestExplore(OpenForestExploreEvent e)
        {
            StateMachine.ChangeState<ForestExploreState>();
        }
    }
}