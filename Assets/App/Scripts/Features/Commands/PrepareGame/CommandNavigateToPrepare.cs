using App.Scripts.Features.AppStates;
using App.Scripts.Infrastructure.Buttons;
using App.Scripts.Infrastructure.EasyStateMachine;

namespace App.Scripts.Features.Commands.PrepareGame
{
    public class CommandNavigateToPrepare : BaseCommandButton, ICommandNavigateToMenu
    {
        private readonly IStateMachine _stateMachine;

        public CommandNavigateToPrepare(IStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }
        
        public override void Execute()
        {
            _stateMachine.RequestSwitchState<StatePrepareGeneration>();
        }
    }
}