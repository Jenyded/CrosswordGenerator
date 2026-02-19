using App.Scripts.Features.Crosswords.CrossWordGenerator.Models;
using App.Scripts.Infrastructure.Buttons;
using Zenject;

namespace App.Scripts.Features.Crosswords.Commands
{
    public class CommandStartGenerateFactory : ICommandStartGenerateFactory
    {
        private readonly IInstantiator _instantiator;

        public CommandStartGenerateFactory(IInstantiator instantiator)
        {
            _instantiator = instantiator;
        }

        public ICommandButton Create(GenerationOptions options)
        {
            return _instantiator.Instantiate<CommandStartGenerate>(new object[] { options });
        }
    }
}
