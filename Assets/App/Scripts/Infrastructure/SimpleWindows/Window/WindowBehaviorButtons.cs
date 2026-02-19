using System.Collections.Generic;
using App.Scripts.Infrastructure.Buttons;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace App.Scripts.Infrastructure.SimpleWindows.Window
{
    public class WindowBehaviorButtons : WindowBehavior
    {
        [SerializeField] private List<ButtonBinding> _buttons = new();

        public ButtonBinding GetBinding(string key)
        {
            foreach (ButtonBinding binding in _buttons)
            {
                if (binding.key == key)
                    return binding;
            }
            return null;
        }

        public void SetupButton(string key, ICommandButton command)
        {
            ButtonBinding binding = GetBinding(key);
            if (binding?.button != null)
                binding.button.SetCommand(command);
        }

        public void SetupButtons(IReadOnlyDictionary<string, ICommandButton> commands)
        {
            if (commands == null)
                return;

            foreach (var kvp in commands)
                SetupButton(kvp.Key, kvp.Value);
        }

        public override UniTask Hide()
        {
            ClearAllButtons();
            return UniTask.CompletedTask;
        }

        private void ClearAllButtons()
        {
            foreach (ButtonBinding binding in _buttons)
            {
                if (binding.button != null)
                    binding.button.Clear();
            }
        }

        [System.Serializable]
        public class ButtonBinding
        {
            public string key;
            public ViewCommandButton button;
        }
    }
}
