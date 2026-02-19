using App.Scripts.Features.Windows.WindowSettings.Models;
using App.Scripts.Infrastructure.SimpleMath;
using TMPro;
using UnityEngine;

namespace App.Scripts.Features.Windows.WindowSettings.Views
{
    public class ViewItemFloat : BaseViewItem<ItemSettingsFloatModel>
    {
        [SerializeField] private TMP_Text textLabel;
        [SerializeField] private TMP_InputField textValue;

        private ItemSettingsFloatModel _model;
        private float _innerValue;

        private const string FloatSeparators = ",.";

        private void Awake()
        {
            textValue.onValueChanged.AddListener(OnValueChanged);
        }

        private void OnValueChanged(string newValue)
        {
            if (HasSeparator(newValue))
            {
                return;
            }
            
            if (FloatParser.TryParseFloat(newValue, out var nextValue))
            {
                _model?.UpdateValue(nextValue);
            }
            
            UpdateView(_model);
        }

        private static bool HasSeparator(string newValue)
        {
            return newValue.Length > 0 && FloatSeparators.IndexOf(newValue[^1]) >= 0;
        }

        protected override void OnSetup(ItemSettingsFloatModel typedModel)
        {
            _model = typedModel;
            UpdateView(typedModel);
        }

        private void UpdateView(ItemSettingsFloatModel typedModel)
        {
            if (typedModel is null)
            {
                return;
            }

            _innerValue = typedModel.Value;
            textLabel.text = typedModel.Label;
            textValue.text = _innerValue.ToString();
        }
    }
}
