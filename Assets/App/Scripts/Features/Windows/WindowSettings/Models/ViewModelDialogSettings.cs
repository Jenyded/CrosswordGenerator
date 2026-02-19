using System.Collections.Generic;
using App.Scripts.Features.Crosswords.CrossWordGenerator.Models;

namespace App.Scripts.Features.Windows.WindowSettings.Models
{
    public class ViewModelDialogSettings
    {
        public List<IItemSettingsModel> SettingsModels { get; }
        public GenerationOptions GenerationOptions { get; }

        public ViewModelDialogSettings(GenerationOptions generationOptions, List<IItemSettingsModel> settingsModels)
        {
            GenerationOptions = generationOptions;
            SettingsModels = settingsModels;
        }
    }
}