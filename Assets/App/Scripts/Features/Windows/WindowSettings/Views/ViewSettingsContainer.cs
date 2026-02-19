using System.Collections.Generic;
using App.Scripts.Features.Windows.WindowSettings.Models;
using App.Scripts.Infrastructure.Logger.Interfaces;
using App.Scripts.Infrastructure.Visuals.Config;
using UnityEngine;
using Zenject;

namespace App.Scripts.Features.Windows.WindowSettings.Views
{
    public class ViewSettingsContainer : MonoBehaviour
    {
        [SerializeField] private RectTransform container;
        [SerializeField] private ConfigKeyPrefabs configKeyPrefabs;

        private IInstantiator _instantiator;
        private IAppLogger _logger;
        private readonly List<BaseViewItemBase> _instancedItems = new List<BaseViewItemBase>();

        [Inject]
        private void Construct(IInstantiator instantiator, IAppLogger logger)
        {
            _instantiator = instantiator;
            _logger = logger;
        }

        public void UpdateItems(IEnumerable<IItemSettingsModel> settingsModels)
        {
            ClearItems();

            if (settingsModels == null || container == null || _instantiator == null)
                return;

            foreach (var model in settingsModels)
            {
                if (string.IsNullOrEmpty(model?.Id))
                    continue;

                var prefab = GetPrefabById(model.Id);
                if (prefab == null)
                {
                    _logger?.Log($"Prefab for settings id '{model.Id}' not found.");
                    continue;
                }

                var instance = _instantiator.InstantiatePrefabForComponent<BaseViewItemBase>(prefab, container);
                instance.Setup(model);
                _instancedItems.Add(instance);
            }
        }

        private void ClearItems()
        {
            foreach (var item in _instancedItems)
            {
                if (item != null)
                {
                    item.Clear();
                    Destroy(item.gameObject);
                }
            }
            _instancedItems.Clear();
        }

        private BaseViewItemBase GetPrefabById(string id)
        {
            return configKeyPrefabs != null ? configKeyPrefabs.GetPrefab<BaseViewItemBase>(id) : null;
        }
    }
}