﻿using UnityEngine;

namespace _project.Scripts.Infrastructure
{
    public class LoadLevelState : IPayloadedState<string>
    {
        private const string _initialPoint = "PlayerInitialPoint";
        private const string _charPath = "Character/Character";
        private const string _hudPath = "HUD/InventoryHUD";
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
            var initialPoint = GameObject.FindGameObjectWithTag(_initialPoint);
            GameObject character = Instantiate(_charPath, initialPoint.transform.position);
            GameObject inventoryHUD = Instantiate(_hudPath);
            
            Game.InterfaceSystem.SetInventoryCanvas(inventoryHUD);
            
            CameraFollow(character);
            
            _gameStateMachine.Enter<GameLoopState>();
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
        
        private static GameObject Instantiate(string path, Vector3 at)
        {
            var prefab = Resources.Load<GameObject>(path);
            var instance = Object.Instantiate(prefab, at, Quaternion.identity);
            return instance;
        }
    }
}