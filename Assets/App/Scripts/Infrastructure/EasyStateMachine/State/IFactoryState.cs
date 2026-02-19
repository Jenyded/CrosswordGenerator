using System;

namespace App.Scripts.Infrastructure.EasyStateMachine.State
{
    public interface IFactoryState
    {
        IState GetState(Type stateType);
    }
}
