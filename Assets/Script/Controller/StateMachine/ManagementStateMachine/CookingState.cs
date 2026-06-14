using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ManagementState
{
    public class CookingState : ManagementState
    {
        private CanvasGroup canvasGroup;
        public CookingState(ManagementStateMachine managementStateMachine) : base(managementStateMachine)
        {
        }

        public override void Enter()
        {
            EventBus.Subscribe<OpenRestaurantPanelEvent>(ToRestaurantState);
            canvasGroup=GameObject.Find("Cooking").GetComponent<CanvasGroup>();
            canvasGroup.alpha = 1;
            canvasGroup.interactable = true;
            canvasGroup.blocksRaycasts = true;
        }
        public override void Exit()
        {
            canvasGroup.alpha= 0f;
            canvasGroup.interactable = false;
            canvasGroup.blocksRaycasts = false;
            EventBus.UnSubscribe<OpenRestaurantPanelEvent>(ToRestaurantState);
        }
        private void ToRestaurantState(OpenRestaurantPanelEvent e)
        {
            StateMachine.ChangeState<RestaurantState>();
        }
    }
}