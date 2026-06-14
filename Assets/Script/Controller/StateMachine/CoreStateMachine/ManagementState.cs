using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/// <summary>
/// ¾­Óª×´Ì¬£¨Íæ·¨×´Ì¬£©
/// </summary>
namespace CoreState
{
    public class ManagementState : CoreState
    {
        ManagementController managementController;
        public ManagementState(CoreStateMachine stateMachine) : base(stateMachine)
        {
        }

        public override void Enter()
        {
            Debug.Log("Core ManagementState Enter");
            EventBus.Subscribe<ToMainMenuEvent>(ToMainMenu);
            EventBus.Publish<SwitchBGMEvent>(new SwitchBGMEvent(BGMAudioType.Hotel));
        }
        public override void Exit()
        {
            EventBus.UnSubscribe<ToMainMenuEvent>(ToMainMenu);
        }
        private void ToMainMenu(ToMainMenuEvent e)
        {
            SceneManager.sceneLoaded += OnHomeLoaded;
            SceneManager.LoadScene("Home");
        }

        private void OnHomeLoaded(Scene scene, LoadSceneMode mode)
        {
            if (scene.name != "Home") return;

            SceneManager.sceneLoaded -= OnHomeLoaded;
            stateMachine.ChangeState<HomeState>();
        }
    }
}