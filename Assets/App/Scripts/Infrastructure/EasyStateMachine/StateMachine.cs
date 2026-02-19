using System;
using App.Scripts.Infrastructure.EasyStateMachine.State;
using App.Scripts.Infrastructure.EasyStateMachine.Transition;
using Cysharp.Threading.Tasks;

namespace App.Scripts.Infrastructure.EasyStateMachine
{
    public class StateMachine : IStateMachine
    {
        private readonly IFactoryState _stateFactory;
        private IState _currentState;
        private bool _isTransitioning;
        private RequestSwitchState _pendingRequest;

        public IState CurrentState => _currentState;

        public StateMachine(IFactoryState stateFactory)
        {
            _stateFactory = stateFactory ?? throw new ArgumentNullException(nameof(stateFactory));
        }

        public void RequestSwitchState<T>() where T : IState
        {
            if (_pendingRequest is not null)
                throw new InvalidOperationException($"State switch already requested to {_pendingRequest.StateType.Name}. Process the current request in Update before requesting another.");

            _pendingRequest = new RequestSwitchState(typeof(T));
        }

        public void Update(float dt)
        {
            _currentState?.Update(dt);

            if (_pendingRequest is null || _isTransitioning)
                return;

            var request = _pendingRequest;
            _pendingRequest = null;
            TransitionToAsync(request).Forget();
        }

        private async UniTaskVoid TransitionToAsync(RequestSwitchState request)
        {
            _isTransitioning = true;

            try
            {
                if (_currentState != null)
                    await _currentState.OnExit();

                var newState = _stateFactory.GetState(request.StateType);
                if (newState is null)
                    throw new InvalidOperationException($"State factory returned null for type {request.StateType.Name}.");

                newState.StateMachine = this;
                _currentState = newState;
                await _currentState.OnEnter();
            }
            finally
            {
                _isTransitioning = false;
            }
        }
    }
}