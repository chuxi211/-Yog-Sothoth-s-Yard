using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ManagementState
{
    public class ModifyMenuState : ManagementState
    {
        private CanvasGroup canvasGroup;
        public ModifyMenuState(ManagementStateMachine managementStateMachine) : base(managementStateMachine)
        {
        }

        public override void Enter()
        {
            EventBus.Subscribe<CloseModifyMenuPanelEvent>(CloseCurrentPanel);
            canvasGroup=GameObject.Find("ModifyMenu").GetComponent<CanvasGroup>();
            if (canvasGroup != null)
            {
                canvasGroup.alpha = 1;
                canvasGroup.interactable = true;
                canvasGroup.blocksRaycasts = true;
            }
        }
        public override void Exit()
        {
            canvasGroup.alpha = 0;
            canvasGroup.interactable = false;
            canvasGroup.blocksRaycasts = false;
            EventBus.UnSubscribe<CloseModifyMenuPanelEvent>(CloseCurrentPanel);
        }
        public void CloseCurrentPanel(CloseModifyMenuPanelEvent e)
        {
            StateMachine.ChangeState<RestaurantState>();
        }
    }
}