using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace CoreState
{
    /// <summary>
    /// Ö÷Ò³×´Ì¬
    /// </summary>
    public class HomeState : CoreState
    {
        public HomeState(CoreStateMachine stateMachine) : base(stateMachine)
        {
        }

        public override void Enter()
        {
            EventBus.Subscribe<RequestNewGameEvent>(NewGame);
            EventBus.Subscribe<RequestToLoadSceneEvent>(ToLoadScene);
            EventBus.Subscribe<RequestGalleryEvent>(ToGalleryState);
            EventBus.Subscribe<RequestExitGameEvent>(ToExitState);
            EventBus.Publish(new SwitchBGMEvent(BGMAudioType.MainMenu));
        }
        public override void Exit()
        {
            EventBus.UnSubscribe<RequestNewGameEvent>(NewGame);
            EventBus.UnSubscribe<RequestToLoadSceneEvent>(ToLoadScene);
            EventBus.UnSubscribe<RequestGalleryEvent>(ToGalleryState);
            EventBus.UnSubscribe<RequestExitGameEvent>(ToExitState);
        }
        private void NewGame(RequestNewGameEvent e)
        {
            SceneManager.sceneLoaded += OnSceneLoaded;
            SceneManager.LoadScene("Yard");
        }
        private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            if (scene.name == "Yard")
            {
                SceneManager.sceneLoaded -= OnSceneLoaded;
                stateMachine.ChangeState<ManagementState>();
            }

        }
        private void ToLoadScene(RequestToLoadSceneEvent e)
        {

        }
        private void ToGalleryState(RequestGalleryEvent e)
        {
            stateMachine.ChangeState<GalleryState>();
        }
        private void ToExitState(RequestExitGameEvent e)
        {
            stateMachine.ChangeState<ExitState>();
        }
    }
}