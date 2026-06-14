using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ManagementState
{
    public class RunningState : ManagementState
    {
        public RunningState(ManagementStateMachine managementStateMachine) : base(managementStateMachine)
        {
        }

        public override void Enter()
        {
            Debug.Log("Enter RunningState");
            EventBus.Subscribe<RequestMainManagePanelEvent>(ToMainManageState);
            EventBus.Subscribe<RequestFloorChangePanelEvent>(ToFloorChangeState);
            EventBus.Subscribe<RequestExplorePanelEvent>(ToExploreState);
            EventBus.Subscribe<MonthSwitchedEvent>(ToLevelEvaluationState);
            EventBus.Subscribe<OpenSettingPanelEvent>(ToSettingState);
        }
        public override void Exit()
        {
            EventBus.UnSubscribe<RequestMainManagePanelEvent>(ToMainManageState);
            EventBus.UnSubscribe<RequestFloorChangePanelEvent>(ToFloorChangeState);
            EventBus.UnSubscribe<RequestExplorePanelEvent>(ToExploreState);
            EventBus.UnSubscribe<MonthSwitchedEvent>(ToLevelEvaluationState);
            EventBus.UnSubscribe<OpenSettingPanelEvent>(ToSettingState);
        }
        private void ToMainManageState(RequestMainManagePanelEvent e)
        {
            StateMachine.ChangeState<MainManageState>();
        }
        private void ToFloorChangeState(RequestFloorChangePanelEvent e)
        {
            StateMachine.ChangeState<FloorChangeState>();
        }
        private void ToLevelEvaluationState(MonthSwitchedEvent e)
        {
            StateMachine.PushState(new LevelEvalutionState(StateMachine));
        }
        private void ToExploreState(RequestExplorePanelEvent e)
        {
            StateMachine.ChangeState<ExplorePanelOpenedState>();
        }
        private void ToSettingState(OpenSettingPanelEvent e)
        {
            StateMachine.PushState(new SettingState(StateMachine));
        }
    }
}