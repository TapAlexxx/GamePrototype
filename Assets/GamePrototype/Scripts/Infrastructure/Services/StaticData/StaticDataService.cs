using System.Collections.Generic;
using System.Linq;
using PROJECT_NAME.Scripts.StaticData;
using PROJECT_NAME.Scripts.Window;
using UnityEngine;

namespace PROJECT_NAME.Scripts.Infrastructure.Services.StaticData
{
    public class StaticDataService : IStaticDataService
    {
        private const string GameConfigPath = "StaticData/GameConfig";
        private const string WindowsStaticDataPath = "StaticData/WindowsStaticData";

        private GameStaticData _gameStaticData;
        private Dictionary<WindowTypeId, WindowConfig> _windowConfigs;

        public void LoadData()
        {
            _gameStaticData = Resources
                .Load<GameStaticData>(GameConfigPath);

            _windowConfigs = Resources
                .Load<WindowStaticData>(WindowsStaticDataPath)
                .Configs.ToDictionary(x => x.WindowTypeId, x => x);
        }

        public GameStaticData GameConfig() =>
            _gameStaticData;

        public WindowConfig ForWindow(WindowTypeId windowTypeId) => 
            _windowConfigs[windowTypeId];
    }
}