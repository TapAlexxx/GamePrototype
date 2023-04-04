using GamePrototype.Scripts.Infrastructure.StateMachine;
using GamePrototype.Scripts.Infrastructure.StateMachine.Game.States;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Zenject;

namespace GamePrototype.Scripts.Logic.Hud.Buttons
{
    public class NextLevelButton : MonoBehaviour
    {
        [SerializeField] private Button _button;
        
        private IStateMachine<IGameState> _gameStateMachine;

        private void OnValidate()
        {
            if (!_button) TryGetComponent(out _button);
        }

        [Inject]
        public void Constructor(IStateMachine<IGameState> gameStateMachine) => 
            _gameStateMachine = gameStateMachine;

        private void Start() => 
            _button.onClick.AddListener(LoadNextLevel);

        private void OnDestroy() => 
            _button.onClick.RemoveListener(LoadNextLevel);

        private void LoadNextLevel() => 
            _gameStateMachine.Enter<LoadLevelState, string>(SceneManager.GetActiveScene().name);
    }
}