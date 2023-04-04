using GamePrototype.Scripts.Infrastructure.StateMachine.Game.States;

namespace GamePrototype.Scripts.Infrastructure.StateMachine
{
    public interface IStateFactory
    {
        T GetState<T>() where T : class, IExitable;
    }
}