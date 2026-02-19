using System.Collections.Generic;
using App.Scripts.Features.Crosswords.CrossWordGenerator.Models;
using App.Scripts.Features.Windows.WindowSettings.Config;
using App.Scripts.Features.Windows.WindowSettings.Models;
using App.Scripts.Infrastructure.Values;
using UnityEngine;

namespace App.Scripts.Features.Windows.WindowSettings.Provider
{
    public class ProviderViewModelDialogSettings : IProviderViewModelDialogSettings
    {
        public ViewModelDialogSettings Create()
        {
            var options = new GenerationOptions();
            options.WorldCount = new MinMaxInt { min = 1, max = 50 };
            options.WordCharCount = new MinMaxInt { min = 3, max = 12 };

            var items = new List<IItemSettingsModel>();

            var itemFieldSize = new ItemSettingsMinMaxModel(
                KeysSettingsViews.ViewMinMax,
                val => options.FieldSize = val,
                () => options.FieldSize)
            {
                Label = "Размер поля",
                LabelMin = "Ширина",
                LabelMax = "Высота",
            };
            items.Add(itemFieldSize);

            var itemWorldCount = new ItemSettingsMinMaxModel(
                KeysSettingsViews.ViewMinMax,
                val => options.WorldCount = new MinMaxInt { min = val.x, max = val.y },
                () => new Vector2Int(options.WorldCount.min, options.WorldCount.max))
            {
                Label = "Количество слов",
                LabelMin = "Мин",
                LabelMax = "Макс",
            };
            items.Add(itemWorldCount);

            var itemWordCharCount = new ItemSettingsMinMaxModel(
                KeysSettingsViews.ViewMinMax,
                val => options.WordCharCount = new MinMaxInt { min = val.x, max = val.y },
                () => new Vector2Int(options.WordCharCount.min, options.WordCharCount.max))
            {
                Label = "Максимум букв в слове",
                LabelMin = "Мин",
                LabelMax = "Макс",
            };
            items.Add(itemWordCharCount);

            var itemMaxInputCharCount = new ItemSettingsFloatModel(
                KeysSettingsViews.ViewFloat,
                val => options.MaxInputCharCount = Mathf.RoundToInt(val),
                () => options.MaxInputCharCount)
            {
                Label = "Макс. символов в колесе ввода",
            };
            items.Add(itemMaxInputCharCount);

            var itemDesiredLevelQuality = new ItemSettingsFloatModel(
                KeysSettingsViews.ViewFloat,
                val => options.DesiredLevelQuality = val,
                () => options.DesiredLevelQuality)
            {
                Label = "Ожидаемый уровень качества",
            };
            items.Add(itemDesiredLevelQuality);

            var itemGenerationCount = new ItemSettingsFloatModel(
                KeysSettingsViews.ViewFloat,
                val => options.GenerationCount = (int)val,
                () => options.GenerationCount)
            {
                Label = "Количество уровней",
            };
            items.Add(itemGenerationCount);
            
            return new ViewModelDialogSettings(options, items);
        }
    }
}
