using GamePrototype.Scripts.Infrastructure.Services.Factories.Game;
using GamePrototype.Scripts.Logic.PlayerControl;
using Zenject;

namespace GamePrototype.Scripts.Infrastructure.StateMachine.Game.States
{
    public class GameLoopState : IState, IGameState, IUpdatable
    {
        private IGameFactory _gameFactory;

        [Inject]
        public GameLoopState(IGameFactory gameFactory)
        {
            _gameFactory = gameFactory;
        }

        public void Enter()
        {
            _gameFactory.Player.GetComponent<PlayerStateControl>().EnterPlayState();
        }

        public void Update()
        {
            
        }

        public void Exit()
        {
            
        }
    }
}