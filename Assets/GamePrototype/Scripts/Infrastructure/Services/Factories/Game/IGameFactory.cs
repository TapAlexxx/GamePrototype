using PROJECT_NAME.Scripts.StaticData;
using UnityEngine;

namespace PROJECT_NAME.Scripts.Infrastructure.Services.Factories.Game
{
    public interface IGameFactory
    {
        GameObject Player { get; }
        GameObject GameHud { get; }
        GameObject CreateHud();
        void Clear();
    }
}