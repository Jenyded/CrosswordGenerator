using System.Collections.Generic;
using App.Scripts.Infrastructure.Logger;
using App.Scripts.Infrastructure.Logger.Interfaces;
using App.Scripts.Infrastructure.SimpleWindows.Config;
using App.Scripts.Infrastructure.SimpleWindows.Window;
using UnityEngine;
using Zenject;

namespace App.Scripts.Infrastructure.SimpleWindows
{
    public class WindowNavigatorZenject : IWindowNavigator
    {
        private readonly DialogConfig _dialogConfig;
        private readonly WindowViewContainer _dialogContainer;
        private readonly IInstantiator _instantiator;
        private readonly IAppLogger _logger;
        private readonly List<WindowView> _createdWindows = new List<WindowView>();

        public WindowNavigatorZenject(DialogConfig dialogConfig, WindowViewContainer dialogContainer, IInstantiator instantiator, IAppLogger logger)
        {
            _dialogConfig = dialogConfig;
            _dialogContainer = dialogContainer;
            _instantiator = instantiator;
            _logger = logger;
        }

        public WindowView CreateWindow(string key)
        {
            WindowView prefab = _dialogConfig.dialogs.Find(d => d.id == key)?.dialogPrefab;
            if (prefab == null)
            {
                _logger.Log($"Window prefab not found for key: {key}");
                return null;
            }

            WindowView instance = _instantiator.InstantiatePrefabForComponent<WindowView>(prefab, _dialogContainer.Container);
            instance.Initialize(this);
            _createdWindows.Add(instance);
            return instance;
        }

        public void ProcessClose(WindowView window)
        {
            if (window == null)
                return;

            _createdWindows.Remove(window);
            if (window.gameObject != null)
                Object.Destroy(window.gameObject);
        }
    }
}