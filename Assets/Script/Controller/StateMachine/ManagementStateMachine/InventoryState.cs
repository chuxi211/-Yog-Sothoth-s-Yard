using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ManagementState
{
    public class InventoryState : ManagementState
    {
        private CanvasGroup canvasGroup;
        public InventoryState(ManagementStateMachine managementStateMachine) : base(managementStateMachine)
        {
        }

        public override void Enter()
        {
            EventBus.Subscribe<CloseInventoryEvent>(CloseInventory);
            canvasGroup=GameObject.Find("Inventory").GetComponent<CanvasGroup>();
            canvasGroup.alpha = 1;
            canvasGroup.interactable = true;
            canvasGroup.blocksRaycasts = true;
        }
        public override void Exit()
        {
            EventBus.UnSubscribe<CloseInventoryEvent>(CloseInventory); 
        }
        private void CloseInventory(CloseInventoryEvent e)
        {
            canvasGroup.alpha = 0;
            canvasGroup.interactable = false;
            canvasGroup.blocksRaycasts = false;
            StateMachine.ChangeState<MainManageState>();
        }
    }
}