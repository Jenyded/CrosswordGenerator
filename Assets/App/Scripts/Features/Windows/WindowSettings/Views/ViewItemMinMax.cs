using App.Scripts.Features.Windows.WindowSettings.Models;
using TMPro;
using UnityEngine;

namespace App.Scripts.Features.Windows.WindowSettings.Views
{
    public class ViewItemMinMax : BaseViewItem<ItemSettingsMinMaxModel>
    {
        [SerializeField] private TMP_Text textLabel;
        [SerializeField] private TMP_Text textLabelMin;
        [SerializeField] private TMP_Text textLabelMax;
        [SerializeField] private TMP_InputField textValueMin;
        [SerializeField] private TMP_InputField textValueMax;
        private ItemSettingsMinMaxModel _model;
        private Vector2Int _innerValue;

        private void Awake()
        {
            textValueMin.onValueChanged.AddListener(OnValueChangedMin);
            textValueMax.onValueChanged.AddListener(OnValueChangedMax);
        }

        private void OnValueChangedMax(string newValue)
        {
            if (int.TryParse(newValue, out var nextValue))
            {
                _model?.UpdateValue(new Vector2Int(_innerValue.x, nextValue));
            }
            
            UpdateView(_model);
        }

        private void OnValueChangedMin(string newValue)
        {
            if (int.TryParse(newValue, out var nextValue))
            {
                _model?.UpdateValue(new Vector2Int(nextValue, _innerValue.y));
            }
            UpdateView(_model);
        }

        protected override void OnSetup(ItemSettingsMinMaxModel typedModel)
        {
            _model = typedModel;
            UpdateView(typedModel);
        }

        private void UpdateView(ItemSettingsMinMaxModel typedModel)
        {
            if (typedModel is null)
            {
                return;
            }
            
            _innerValue = typedModel.Value;
            textLabel.text = typedModel.Label;
            if (textLabelMin != null)
                textLabelMin.text = typedModel.LabelMin;
            if (textLabelMax != null)
                textLabelMax.text = typedModel.LabelMax;
            textValueMax.text = _innerValue.y.ToString();
            textValueMin.text = _innerValue.x.ToString();
        }
    }
}