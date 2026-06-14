using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ManagementState
{
    public class MainManageState : ManagementState
    {
        private CanvasGroup canvasGroup;
        public MainManageState(ManagementStateMachine managementStateMachine) : base(managementStateMachine)
        {
        }

        public override void Enter()
        {
            EventBus.Subscribe<CloseMainManagePanel>(CloseCurrentPanel);
            EventBus.Subscribe<OpenCleanEvent>(OpenCleanPanel);
            EventBus.Subscribe<OpenInventoryEvent>(OpenInventroy);
            EventBus.Subscribe<OpenRestaurantPanelEvent>(OpenRestaurantPanel);
            canvasGroup = GameObject.Find("ManagePanel").GetComponent<CanvasGroup>();
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
            EventBus.UnSubscribe<CloseMainManagePanel>(CloseCurrentPanel);
            EventBus.UnSubscribe<OpenCleanEvent>(OpenCleanPanel);
            EventBus.UnSubscribe<OpenInventoryEvent>(OpenInventroy);
            EventBus.UnSubscribe<OpenRestaurantPanelEvent>(OpenRestaurantPanel);
        }
        private void CloseCurrentPanel(CloseMainManagePanel e)
        {
            StateMachine.ChangeState<RunningState>();
        }
        private void OpenCleanPanel(OpenCleanEvent e)
        {
            StateMachine.ChangeState<CleanPanelOpenedState>();
        }
        private void OpenInventroy(OpenInventoryEvent e)
        {
            StateMachine.ChangeState<InventoryState>();
        }
        private void OpenRestaurantPanel(OpenRestaurantPanelEvent e)
        {
            StateMachine.ChangeState<RestaurantState>();
        }
    }
}