using GamePrototype.Scripts.Logic.LevelGeneration;
using GamePrototype.Scripts.StaticData;
using UnityEngine;

namespace GamePrototype.Scripts.Infrastructure.Services.Factories.Game
{
    public interface IGameFactory
    {
        GameObject Player { get; }
        GameObject GameHud { get; }
        GameObject CreateHud();
        void CreatePlayer(PlayerTypeId playerTypeId, Transform spawnMarkerTransform);
        GameObject CreateLevelGenerator();
        void Clear();
    }
}