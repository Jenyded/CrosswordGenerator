using System.Collections.Generic;
using App.Scripts.Features.Windows.WindowSettings.Models;
using App.Scripts.Features.Windows.WindowSettings.Views;
using App.Scripts.Infrastructure.SimpleWindows;
using App.Scripts.Infrastructure.SimpleWindows.Window;
using UnityEngine;

namespace App.Scripts.Features.Windows.WindowSettings
{
    public class WindowBehaviorViewSettings : WindowBehavior
    {
        [SerializeField] private ViewSettingsContainer viewSettingsContainer;

        public void UpdateViewItems(IEnumerable<IItemSettingsModel> settingsModels)
        {
            viewSettingsContainer?.UpdateItems(settingsModels);
        }
    }
}
