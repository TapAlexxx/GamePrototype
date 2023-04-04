using System.Collections.Generic;
using System.Linq;
using GamePrototype.Scripts.StaticData;
using GamePrototype.Scripts.Window;
using UnityEngine;

namespace GamePrototype.Scripts.Infrastructure.Services.StaticData
{
    public class StaticDataService : IStaticDataService
    {
        private const string GameConfigPath = "StaticData/GameConfig";
        private const string WindowsStaticDataPath = "StaticData/WindowsStaticData";
        private const string PlayerConfigsPath = "StaticData/PlayerConfigs";
        private const string LevelGenerationConfigPath = "StaticData/LevelGenerationConfigs/Default";

        private GameStaticData _gameStaticData;
        private Dictionary<WindowTypeId, WindowConfig> _windowConfigs;
        private List<PlayerConfig> _playerConfigs;
        private LevelGenerationConfig _levelGenerationConfig;

        public void LoadData()
        {
            _gameStaticData = Resources
                .Load<GameStaticData>(GameConfigPath);

            _windowConfigs = Resources
                .Load<WindowStaticData>(WindowsStaticDataPath)
                .Configs.ToDictionary(x => x.WindowTypeId, x => x);

            _playerConfigs = Resources
                .LoadAll<PlayerConfig>(PlayerConfigsPath)
                .ToList();

            _levelGenerationConfig = Resources
                .Load<LevelGenerationConfig>(LevelGenerationConfigPath);
        }

        public PlayerConfig PlayerConfigFor(PlayerTypeId playerTypeId) =>
            _playerConfigs.FirstOrDefault(x => x.PlayerTypeId == playerTypeId);

        public LevelGenerationConfig LevelGenerationConfig() => 
            _levelGenerationConfig;

        public GameStaticData GameConfig() =>
            _gameStaticData;

        public WindowConfig ForWindow(WindowTypeId windowTypeId) => 
            _windowConfigs[windowTypeId];
    }
}