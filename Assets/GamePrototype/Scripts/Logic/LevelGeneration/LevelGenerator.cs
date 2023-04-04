using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace GamePrototype.Scripts.Logic.LevelGeneration
{
    public class LevelGenerator : MonoBehaviour
    {
        private const int YPosition = -15;
        
        [SerializeField] private int _startZPosition;
        [SerializeField] private Vector2 _xSpawnRange;
        [Space]
        [SerializeField] private int _rowCount;
        [SerializeField] private int _obstaclesInRow;
        [SerializeField] private float _rowStepRate;
        [SerializeField] private ObstaclePool _pool;

        private void OnValidate()
        {
            if (!_pool) TryGetComponent(out _pool);
        }

        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.Space))
                GenerateLevel();
        }

        public void GenerateLevel()
        {
            _pool.Reset();
            float currentZ = _startZPosition;
            for (int i = 0; i < _rowCount; i++)
            {
                for (int j = 0; j < _obstaclesInRow; j++)
                {
                    if (_pool.TryGetRandomObstacle(out GameObject obstacle)) 
                        PlaceObstacle(obstacle, currentZ);
                }
                
                currentZ += _rowStepRate;
            }
        }

        private void PlaceObstacle(GameObject obstacle, float currentZ)
        {
            obstacle.transform.position = GetNewPosition(currentZ, _xSpawnRange);
            obstacle.SetActive(true);
        }

        private Vector3 GetNewPosition(float currentZ, Vector2 xSpawnRange) => 
            new Vector3(Random.Range((int)xSpawnRange.x, (int)xSpawnRange.y), YPosition, currentZ);
    }
}