using System.Collections.Generic;
using System.Linq;
using GamePrototype.Scripts.Infrastructure.Services.StaticData;
using GamePrototype.Scripts.StaticData;
using UnityEngine;
using Zenject;

namespace GamePrototype.Scripts.Logic.LevelGeneration
{
    public class ObstaclePool : MonoBehaviour
    {
        [SerializeField] private int _eachObstacleCount;
        
        private IStaticDataService _staticDataService;
        private LevelGenerationConfig _levelGenerationConfig;
        private List<GameObject> _pool;
        private Transform _parent;

        [Inject]
        public void Constructor(IStaticDataService staticDataService)
        {
            _staticDataService = staticDataService;
        }

        public void InitializePool()
        {
            TryCreateParent();
            Clear();

            _levelGenerationConfig = _staticDataService.LevelGenerationConfig();

            foreach (GameObject obstacle in _levelGenerationConfig.Obstacles)
            {
                for (int i = 0; i < _eachObstacleCount; i++)
                {
                    GameObject obstacleToPool = Instantiate(obstacle, _parent);
                    obstacleToPool.SetActive(false);
                    _pool.Add(obstacleToPool);
                }
            }
        }

        private void TryCreateParent()
        {
            if(_parent != null)
                return;
            
            _parent = new GameObject()
            {
                name = "poolParent",
                transform =
                {
                    position = Vector3.zero,
                    rotation = Quaternion.identity
                }
            }.transform;
        }

        private void Clear()
        {
            foreach (Transform child in _parent) 
                Destroy(child);
            _pool = new List<GameObject>();
        }

        public bool TryGetRandomObstacle(out GameObject obstacle)
        {
            obstacle = _pool[Random.Range(0, _pool.Count)];
            while (obstacle.activeSelf == true)
            {
                obstacle = _pool[Random.Range(0, _pool.Count)];
            }
            return obstacle != null;
        }

        public void Reset()
        {
            foreach (GameObject obstacle in _pool) 
                obstacle.SetActive(false);
        }
    }
}