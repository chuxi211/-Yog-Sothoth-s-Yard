using UnityEngine;
namespace ManagementState
{
    public class RestaurantState : ManagementState
    {
        private CanvasGroup canvasGroup;
        public RestaurantState(ManagementStateMachine managementStateMachine) : base(managementStateMachine)
        {
        }

        public override void Enter()
        {
            EventBus.Subscribe<CloseRestaurantPanelEvent>(CloseRestaurantPanel);
            EventBus.Subscribe<OpenModifyMenuPanelEvent>(OpenModifyMenuPanel);
            EventBus.Subscribe<OpenCookingPanelEvent>(OpenCookingPanel);
            canvasGroup = GameObject.Find("Restaurant").GetComponent<CanvasGroup>();
            canvasGroup.alpha = 1;
            canvasGroup.interactable = true;
            canvasGroup.blocksRaycasts = true;
        }
        public override void Exit()
        {
            canvasGroup.alpha = 0f;
            canvasGroup.interactable = false;
            canvasGroup.blocksRaycasts = false;
            EventBus.UnSubscribe<OpenModifyMenuPanelEvent>(OpenModifyMenuPanel);
            EventBus.UnSubscribe<CloseRestaurantPanelEvent>(CloseRestaurantPanel);
            EventBus.UnSubscribe<OpenCookingPanelEvent>(OpenCookingPanel);
        }
        private void CloseRestaurantPanel(CloseRestaurantPanelEvent e)
        {
            StateMachine.ChangeState<MainManageState>();
        } 
        private void OpenModifyMenuPanel(OpenModifyMenuPanelEvent e)
        {
            StateMachine.ChangeState<ModifyMenuState>();
        }
        private void OpenCookingPanel(OpenCookingPanelEvent e)
        {
            StateMachine.ChangeState<CookingState>();
        }
    }
}
