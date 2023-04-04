using System;
using GamePrototype.Scripts.Infrastructure.Services.Factories.Game;
using GamePrototype.Scripts.Infrastructure.Services.Factories.UIFactory;
using GamePrototype.Scripts.Logic;
using GamePrototype.Scripts.Logic.CameraControl;
using GamePrototype.Scripts.Logic.LevelGeneration;
using GamePrototype.Scripts.Logic.SpawnControl;
using GamePrototype.Scripts.StaticData;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;
using Object = UnityEngine.Object;

namespace GamePrototype.Scripts.Infrastructure.StateMachine.Game.States
{
    public class LoadLevelState : IPayloadedState<string>, IGameState
    {
        private readonly ISceneLoader _sceneLoader;
        private readonly ILoadingCurtain _loadingCurtain;
        private readonly IUIFactory _uiFactory;
        private readonly IStateMachine<IGameState> _gameStateMachine;
        private IGameFactory _gameFactory;
        private DiContainer _diContainer;

        [Inject]
        public LoadLevelState(
            IStateMachine<IGameState> gameStateMachine,
            ISceneLoader sceneLoader, 
            ILoadingCurtain loadingCurtain, 
            IUIFactory uiFactory, IGameFactory gameFactory,
            DiContainer diContainer)
        {
            _diContainer = diContainer;
            _gameFactory = gameFactory;
            _gameStateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
            _loadingCurtain = loadingCurtain;
            _uiFactory = uiFactory;
        }

        public void Enter(string payload)
        {
            _loadingCurtain.Show();
            _sceneLoader.Load(payload, OnLevelLoad);
        }

        public void Exit()
        {
            _loadingCurtain.Hide();
        }

        protected virtual void OnLevelLoad()
        {
            InitGameWorld();
            
            _gameStateMachine.Enter<GameLoopState>();
        }

        private void InitGameWorld()
        {
           _uiFactory.CreateUiRoot();
           _gameFactory.Clear();

           InitHud();
           InitPlayer();
           InitLevelGenerator();
           
           Inject<Finish>();
        }

        private void InitLevelGenerator()
        {
            var levelGeneratorObject = _gameFactory.CreateLevelGenerator();
            var levelGenerator = levelGeneratorObject.GetComponent<LevelGenerator>();
            var obstaclePool= levelGeneratorObject.GetComponent<ObstaclePool>();
            obstaclePool.InitializePool();
            levelGenerator.GenerateLevel();
        }

        private void InitPlayer()
        {
            PlayerSpawnMarker spawnMarker = Object.FindObjectOfType<PlayerSpawnMarker>();
            if (!spawnMarker)
                throw new NullReferenceException($"no player spawnMarker on scene - {SceneManager.GetActiveScene().name}");
            
            _gameFactory.CreatePlayer(PlayerTypeId.Default, spawnMarker.transform);
        }

        private void InitHud()
        {
            GameObject hud = _gameFactory.CreateHud();
        }

        private void Inject<T>() where T : Object
        {
            foreach (var injectable in Object.FindObjectsOfType<T>())
                _diContainer.Inject(injectable);
        }
    }
}