using System;

namespace PROJECT_NAME.Scripts.Infrastructure
{
    public interface ISceneLoader
    {
        void Load(string name, Action onLevelLoad);
    }
}