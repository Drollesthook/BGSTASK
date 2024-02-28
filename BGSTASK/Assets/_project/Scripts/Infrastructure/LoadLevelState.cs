using UnityEngine;

namespace _project.Scripts.Infrastructure
{
    public class LoadLevelState : IPayloadedState<string>
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly SceneLoader _sceneLoader;

        public LoadLevelState(GameStateMachine gameStateMachine, SceneLoader sceneLoader)
        {
            _gameStateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
        }

        public void Enter(string sceneName)
        {
            _sceneLoader.Load(sceneName, OnLoaded);
        }

        public void Exit()
        {
        }

        private void OnLoaded()
        {
            GameObject character = Instantiate("Character/Character");
            GameObject inventoryHUD = Instantiate("HUD/InventoryHUD");
            Game.InterfaceSystem.SetInventoryCanvas(inventoryHUD);
            
            CameraFollow(character);
        }

        private void CameraFollow(GameObject character)
        {
            Camera.main.GetComponent<CameraFollower>().SetTargetToFollow(character);
        }

        private static GameObject Instantiate(string path)
        {
            var prefab = Resources.Load<GameObject>(path);
            var instance = Object.Instantiate(prefab, Vector3.zero, Quaternion.identity);
            return instance;
        }
    }
}