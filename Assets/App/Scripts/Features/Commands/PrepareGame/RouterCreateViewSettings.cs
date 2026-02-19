using App.Scripts.Features.Crosswords.Commands;
using App.Scripts.Features.Windows;
using App.Scripts.Features.Windows.WindowSettings;
using App.Scripts.Features.Windows.WindowSettings.Provider;
using App.Scripts.Infrastructure.SimpleWindows;
using App.Scripts.Infrastructure.SimpleWindows.Window;

namespace App.Scripts.Features.Commands.PrepareGame
{
    public class RouterCreateViewSettings : IRouterCreateSettings
    {
        private readonly IWindowNavigator _windowNavigator;
        private readonly IProviderViewModelDialogSettings _providerViewModelDialogSettings;
        private readonly ICommandStartGenerateFactory _commandStartGenerateFactory;

        public RouterCreateViewSettings(IWindowNavigator windowNavigator,
            IProviderViewModelDialogSettings providerViewModelDialogSettings,
            ICommandStartGenerateFactory commandStartGenerateFactory)
        {
            _windowNavigator = windowNavigator;
            _providerViewModelDialogSettings = providerViewModelDialogSettings;
            _commandStartGenerateFactory = commandStartGenerateFactory;
        }

        public WindowView Create()
        {
            var window = _windowNavigator.CreateWindow(KeysWindows.WindowPrepareGenerate);
            SetupWindow(window);

            return window;
        }

        private void SetupWindow(WindowView window)
        {
            var viewModel = _providerViewModelDialogSettings.Create();
            var viewSettings = window.GetBehavior<WindowBehaviorViewSettings>();
            viewSettings.UpdateViewItems(viewModel.SettingsModels);

            var buttons = window.GetBehavior<WindowBehaviorButtons>();
            buttons.SetupButton(KeysButtons.ButtonGenerate,
                _commandStartGenerateFactory.Create(viewModel.GenerationOptions));
        }
    }
}