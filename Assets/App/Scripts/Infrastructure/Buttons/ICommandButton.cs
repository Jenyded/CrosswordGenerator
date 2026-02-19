using System;

namespace App.Scripts.Infrastructure.Buttons
{
    public interface ICommandButton
    {
        event Action<bool> OnStateChanged;

        bool CanExecute { get; }
        void Execute();
    }
}
