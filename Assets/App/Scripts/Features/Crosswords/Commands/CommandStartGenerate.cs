using App.Scripts.Features.AppStates;
using App.Scripts.Features.Crosswords.CrossWordGenerator.Config;
using App.Scripts.Features.Crosswords.CrossWordGenerator.Models;
using App.Scripts.Infrastructure.Buttons;
using App.Scripts.Infrastructure.EasyStateMachine;

namespace App.Scripts.Features.Crosswords.Commands
{
    public class CommandStartGenerate : BaseCommandButton
    {
        private readonly GenerationOptions _options;
        private readonly ICrosswordGenerateOptionsProvider _optionsProvider;
        private readonly IStateMachine _stateMachine;

        public CommandStartGenerate(GenerationOptions options, ICrosswordGenerateOptionsProvider optionsProvider, 
            IStateMachine stateMachine)
        {
            _options = options;
            _optionsProvider = optionsProvider;
            _stateMachine = stateMachine;
        }

        public override void Execute()
        {
            _optionsProvider.Setup(_options);
            _stateMachine.RequestSwitchState<StateProcessGenerate>();
        }
    }
}