using System;

namespace App.Scripts.Infrastructure.Buttons
{
    public abstract class BaseCommandButton : ICommandButton
    {
        public event Action<bool> OnStateChanged;

        public virtual bool CanExecute { get; set; } = true;
        
        public abstract void Execute();

        protected void OnChanged(bool state)
        {
            OnStateChanged?.Invoke(state);
        }
    }
}
