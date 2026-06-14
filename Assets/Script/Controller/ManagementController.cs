using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 经营控制器，子状态机入口
/// </summary>
public class ManagementController: MonoBehaviour 
{
    public ManagementState.ManagementStateMachine StateMachine { get; private set; }
    private void Awake()
    {
        InitStateMachine();
        Debug.Log("ManagementController Awake");
    }
    private void InitStateMachine()
    {
        StateMachine = new ManagementState.ManagementStateMachine();
        StateMachine.RegisterState(new ManagementState.InitState(StateMachine));
        StateMachine.RegisterState(new ManagementState.RunningState(StateMachine));
        StateMachine.RegisterState(new ManagementState.MainManageState(StateMachine));
        StateMachine.RegisterState(new ManagementState.FloorChangeState(StateMachine));
        StateMachine.RegisterState(new ManagementState.InventoryState(StateMachine));
        StateMachine.RegisterState(new ManagementState.CleanPanelOpenedState(StateMachine));
        StateMachine.RegisterState(new ManagementState.LevelEvalutionState(StateMachine));
        StateMachine.RegisterState(new ManagementState.ExplorePanelOpenedState(StateMachine));
        StateMachine.RegisterState(new ManagementState.ForestExploreState(StateMachine));
        StateMachine.RegisterState(new ManagementState.RestaurantState(StateMachine));
        StateMachine.RegisterState(new ManagementState.ModifyMenuState(StateMachine));
        StateMachine.RegisterState(new ManagementState.CookingState(StateMachine));
        StateMachine.ChangeState<ManagementState.InitState>();

    }
}