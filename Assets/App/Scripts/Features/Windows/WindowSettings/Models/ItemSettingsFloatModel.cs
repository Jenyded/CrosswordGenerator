using System;

namespace App.Scripts.Features.Windows.WindowSettings.Models
{
    public class ItemSettingsFloatModel : IItemSettingsModel
    {
        private readonly Action<float> _setter;
        private readonly Func<float> _getter;

        public string Id { get; private set; }
        public string Label { get; set; }

        public float Value
        {
            get => _getter();
            set => UpdateValue(value);
        }

        public ItemSettingsFloatModel(string id, Action<float> setter, Func<float> getter)
        {
            _setter = setter;
            _getter = getter;
            Id = id;
        }

        public void UpdateValue(float value)
        {
            _setter(value);
        }
    }
}
