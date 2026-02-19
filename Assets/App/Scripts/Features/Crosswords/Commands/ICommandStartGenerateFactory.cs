using App.Scripts.Features.Crosswords.CrossWordGenerator.Models;
using App.Scripts.Infrastructure.Buttons;

namespace App.Scripts.Features.Crosswords.Commands
{
    public interface ICommandStartGenerateFactory
    {
        ICommandButton Create(GenerationOptions options);
    }
}
