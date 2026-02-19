using System;
using UnityEngine;

namespace App.Scripts.Features.Windows.WindowSettings.Models
{
    public class ItemSettingsMinMaxModel : IItemSettingsModel
    {
        private readonly Action<Vector2Int> _setter;
        private readonly Func<Vector2Int> _getter;
        public string Id { get; private set; }

        public string Label { get; set; }
        public string LabelMin { get; set; }
        public string LabelMax { get; set; }
        
        public Vector2Int Value { get => _getter();
            set => UpdateValue(value);
        }

        public ItemSettingsMinMaxModel(string id, Action<Vector2Int> setter, Func<Vector2Int> getter)
        {
            _setter = setter;
            _getter = getter;
            Id = id;
        }
        
        public void UpdateValue(Vector2Int value)
        {
            _setter(value);
        }
    }
}