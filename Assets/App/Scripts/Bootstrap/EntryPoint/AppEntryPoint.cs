using App.Scripts.Infrastructure.EasyStateMachine;
using App.Scripts.Infrastructure.EasyStateMachine.State;
using UnityEngine;
using Zenject;

namespace App.Scripts.Bootstrap.EntryPoint
{
    public class AppEntryPoint<T> : IInitializable, ITickable where T : IState
    {
        private readonly IStateMachine _stateMachine;

        public AppEntryPoint(IStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }

        public void Initialize()
        {
            _stateMachine.RequestSwitchState<T>();
        }

        public void Tick()
        {
            _stateMachine.Update(Time.deltaTime);
        }
    }
}