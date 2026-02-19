using System;
using Zenject;

namespace App.Scripts.Infrastructure.EasyStateMachine.State
{
    public class FactoryStateZenject : IFactoryState
    {
        private readonly IInstantiator _container;

        public FactoryStateZenject(IInstantiator container)
        {
            _container = container;
        }
        
        public IState GetState(Type stateType)
        {
            return _container.Instantiate(stateType) as IState;
        }
    }
}