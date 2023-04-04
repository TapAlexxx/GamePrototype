using System;

namespace GamePrototype.Scripts.Infrastructure
{
    public interface ISceneLoader
    {
        void Load(string name, Action onLevelLoad);
    }
}