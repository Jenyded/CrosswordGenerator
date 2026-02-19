using App.Scripts.Features.Commands.Generate;
using App.Scripts.Infrastructure.EasyStateMachine.State;
using Cysharp.Threading.Tasks;

namespace App.Scripts.Features.AppStates
{
    public class StateProcessGenerate : BaseState
    {
        private readonly ICommandProcessGenerateCrossword _commandProcessGenerateCrossword;

        public StateProcessGenerate(ICommandProcessGenerateCrossword commandProcessGenerateCrossword)
        {
            _commandProcessGenerateCrossword = commandProcessGenerateCrossword;
        }

        public override async UniTask OnEnter()
        {
            await _commandProcessGenerateCrossword.Execute();
            StateMachine.RequestSwitchState<StateViewGenerations>();
        }
    }
}