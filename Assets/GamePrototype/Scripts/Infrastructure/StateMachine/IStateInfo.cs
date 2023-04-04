
using System;

namespace PROJECT_NAME.Scripts.Infrastructure.StateMachine
{
    public interface IStateInfo
    {
        Type StateType { get; }
        void Enter();
        void Update();
        void Exit();
    }
}