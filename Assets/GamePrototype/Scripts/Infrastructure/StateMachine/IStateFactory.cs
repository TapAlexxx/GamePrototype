using PROJECT_NAME.Scripts.Infrastructure.StateMachine.Game.States;

namespace PROJECT_NAME.Scripts.Infrastructure.StateMachine
{
    public interface IStateFactory
    {
        T GetState<T>() where T : class, IExitable;
    }
}