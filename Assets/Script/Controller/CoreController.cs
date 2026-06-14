using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CoreState;
/// <summary>
/// Holding Sub_Controller
/// The entrance of CoreStateMachine
/// </summary>
public class CoreController:MonoBehaviour
{
    public static CoreController Instance { get; private set; }
    public CoreState.CoreStateMachine StateMachine { get; private set; }
    public StoryController StoryController { get; set; }
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(Instance);
        }
        Instance = this;
        DontDestroyOnLoad(Instance);
        InitCoreStateMachine();
    }
    private void InitCoreStateMachine()
    {
        StateMachine = new CoreState.CoreStateMachine();
        StateMachine.RegisterState(new InitState(StateMachine));
        StateMachine.RegisterState(new StoryState(StateMachine));
        StateMachine.RegisterState(new HomeState(StateMachine));
        StateMachine.RegisterState(new CoreState.ManagementState(StateMachine));
        StateMachine.RegisterState(new GalleryState(StateMachine));
        StateMachine.RegisterState(new ExitState(StateMachine));
        StateMachine.ChangeState<InitState>();
    }
    public void InitSystems()
    {

    }
}