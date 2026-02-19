using App.Scripts.Infrastructure.EasyStateMachine.State;

namespace App.Scripts.Infrastructure.EasyStateMachine
{
    public interface IStateMachine 
    {
        void RequestSwitchState<T>() where T :  IState;
        void Update(float deltaTime);
    }
}