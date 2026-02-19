using System;
using App.Scripts.Infrastructure.EasyStateMachine.State;

namespace App.Scripts.Infrastructure.EasyStateMachine.Transition
{
    public class RequestSwitchState
    {
        public Type StateType { get; }

        public RequestSwitchState(Type stateType)
        {
            StateType = stateType ?? throw new ArgumentNullException(nameof(stateType));
        }

        public static RequestSwitchState To<T>() where T : IState => new RequestSwitchState(typeof(T));
    }
}
