using System.Collections.Generic;
using App.Scripts.Infrastructure.EasyStateMachine.State;
using App.Scripts.Infrastructure.SimplePool;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace App.Scripts.Features.AppStates
{
    public class StateInitializeApp : BaseState
    {
        private readonly IEnumerable<ISimplePool> _pools;

        public StateInitializeApp(IEnumerable<ISimplePool> pools)
        {
            _pools = pools;
        }
        
        public override UniTask OnEnter()
        {
            InitializePools();
            Application.targetFrameRate = 60;
            StateMachine.RequestSwitchState<StatePrepareGeneration>();
            return base.OnEnter();
        }

        private void InitializePools()
        {
            foreach (ISimplePool simplePool in _pools)
            {
                simplePool.Initialize();
            }
        }
    }
}