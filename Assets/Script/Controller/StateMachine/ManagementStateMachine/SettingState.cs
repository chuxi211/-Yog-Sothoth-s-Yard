using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ManagementState
{
    public class SettingState : ManagementState
    {
        private CanvasGroup canvasGroup;
        public SettingState(ManagementStateMachine managementStateMachine) : base(managementStateMachine)
        {
        }

        public override void Enter()
        {
            EventBus.Subscribe<CloseSettingPanelEvent>(CloseSettingPanel);
            canvasGroup =GameObject.Find("SettingPanel").GetComponent<CanvasGroup>();
            if (canvasGroup == null)
            {
                Debug.LogError("CanvasGroup is null");
                return;
            }
            canvasGroup.alpha = 1;
            canvasGroup.interactable = true;
            canvasGroup.blocksRaycasts = true;
        }
        public override void Exit()
        {
            canvasGroup.alpha = 0;
            canvasGroup.interactable = false;
            canvasGroup.blocksRaycasts= false;
            EventBus.UnSubscribe<CloseSettingPanelEvent>(CloseSettingPanel);
        }
        private void CloseSettingPanel(CloseSettingPanelEvent e)
        {
            StateMachine.PopState();
        }
    }
}