using System.Collections.Generic;
using UnityEngine;

namespace GamePrototype.Scripts.StaticData
{
    [CreateAssetMenu(menuName = "StaticData/Level/ObstacleConfig", fileName = "new ObstacleConfig", order = 0)]
    public class LevelGenerationConfig : ScriptableObject
    {
        public GameObject LevelGeneratorPrefab;
        public List<GameObject> Obstacles;
    }
}