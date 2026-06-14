using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace CoreState
{
    public class GalleryState : CoreState
    {
        private CanvasGroup CanvasGroup;
        private CGPanel cGPanel;
        public GalleryState(CoreStateMachine stateMachine) : base(stateMachine)
        {
        }

        public override void Enter()
        {
            Debug.Log("Enter Gallery State");
            EventBus.Subscribe<RequestCloseCGPanel>(CloseCurrentPanel);
            CanvasGroup = GameObject.Find("Canvas/Gallery").GetComponent<CanvasGroup>();
            cGPanel = GameObject.Find("CGPanel").GetComponent<CGPanel>();
            CanvasGroup.alpha = 1;
            CanvasGroup.interactable = true;
            CanvasGroup.blocksRaycasts = true;
            cGPanel.enabled = true;
        }
        public override void Exit()
        {
            Debug.Log("Exit Gallery State");
            EventBus.UnSubscribe<RequestCloseCGPanel>(CloseCurrentPanel);
        }
        private void CloseCurrentPanel(RequestCloseCGPanel e)
        {
            CanvasGroup.alpha = 0;
            CanvasGroup.interactable = false;
            CanvasGroup.blocksRaycasts = false;
            cGPanel.enabled = false;
            stateMachine.ChangeState<HomeState>();
        }
    }
}