using GamePrototype.Scripts.Infrastructure.Services.StaticData;
using GamePrototype.Scripts.Logic.LevelGeneration;
using GamePrototype.Scripts.Logic.PlayerControl;
using GamePrototype.Scripts.StaticData;
using UnityEngine;
using Zenject;

namespace GamePrototype.Scripts.Infrastructure.Services.Factories.Game
{
    public class GameFactory : Factory, IGameFactory
    {
        private IStaticDataService _staticDataService;
        public GameObject Player { get; private set; }
        public GameObject GameHud { get; private set; }



        public GameFactory(IInstantiator instantiator, IStaticDataService staticDataService) : base(instantiator)
        {
            _staticDataService = staticDataService;
        }

        public GameObject CreateHud()
        {
            GameHud = InstantiateOnActiveScene("Hud/Hud");
            return GameHud;
        }

        public void CreatePlayer(PlayerTypeId playerTypeId, Transform spawnMarkerTransform)
        {
            PlayerConfig playerConfig = _staticDataService.PlayerConfigFor(playerTypeId);
            GameObject player = InstantiatePrefabOnActiveScene(playerConfig.Prefab);
            player.transform.position = spawnMarkerTransform.position;
            player.transform.rotation = spawnMarkerTransform.rotation;
            
            player.GetComponent<AimDirectionCalculator>().Initialize(Object.FindObjectOfType<Camera>());
            player.GetComponent<BallShooter>().Initialize(playerConfig);
            
            Player = player;
        }

        public GameObject CreateLevelGenerator()
        {
            LevelGenerationConfig levelGenerationConfig = _staticDataService.LevelGenerationConfig();
            GameObject levelGeneratorObject = InstantiatePrefabOnActiveScene(levelGenerationConfig.LevelGeneratorPrefab);
            levelGeneratorObject.transform.position = Vector3.zero;
            levelGeneratorObject.transform.rotation = Quaternion.identity;
            return levelGeneratorObject;
        }

        public void Clear()
        {
            Player = null;
        }
    }
}