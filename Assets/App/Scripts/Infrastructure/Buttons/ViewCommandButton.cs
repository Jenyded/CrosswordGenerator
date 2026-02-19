using UnityEngine;
using UnityEngine.UI;

namespace App.Scripts.Infrastructure.Buttons
{
    public class ViewCommandButton : MonoBehaviour
    {
        [SerializeField] private Button _button;

        private ICommandButton _command;

        public void Clear()
        {
            if (_command != null)
            {
                _command.OnStateChanged -= OnCommandStateChanged;
                _command = null;
            }
        }

        public void SetCommand(ICommandButton command)
        {
            Clear();

            _command = command;

            if (_command != null)
            {
                _command.OnStateChanged += OnCommandStateChanged;
                UpdateInteractable();
            }
        }

        private void Awake()
        {
            if (_button == null)
                _button = GetComponent<Button>();

            if (_button != null)
                _button.onClick.AddListener(OnClick);
        }

        private void OnDestroy()
        {
            if (_button != null)
                _button.onClick.RemoveListener(OnClick);

            Clear();
        }

        private void OnCommandStateChanged(bool canExecute)
        {
            UpdateInteractable();
        }

        private void OnClick()
        {
            if (_command != null && _command.CanExecute)
                _command.Execute();
        }

        private void UpdateInteractable()
        {
            if (_button != null && _command != null)
                _button.interactable = _command.CanExecute;
        }
    }
}
