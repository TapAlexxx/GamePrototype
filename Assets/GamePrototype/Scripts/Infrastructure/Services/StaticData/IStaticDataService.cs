using GamePrototype.Scripts.StaticData;
using GamePrototype.Scripts.Window;

namespace GamePrototype.Scripts.Infrastructure.Services.StaticData
{
    public interface IStaticDataService
    {
        void LoadData();
        GameStaticData GameConfig();
        WindowConfig ForWindow(WindowTypeId windowTypeId);
        PlayerConfig PlayerConfigFor(PlayerTypeId playerTypeId);
        LevelGenerationConfig LevelGenerationConfig();
    }
}