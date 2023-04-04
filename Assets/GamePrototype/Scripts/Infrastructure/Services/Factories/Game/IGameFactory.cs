using UnityEngine;

namespace GamePrototype.Scripts.Infrastructure.Services.Factories.Game
{
    public interface IGameFactory
    {
        GameObject Player { get; }
        GameObject GameHud { get; }
        GameObject CreateHud();
        void Clear();
    }
}