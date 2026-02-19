using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace App.Scripts.Infrastructure.SimpleWindows.Window
{
    [RequireComponent(typeof(Canvas))]
    [RequireComponent(typeof(GraphicRaycaster))]
    public class WindowView : MonoBehaviour
    {
        [SerializeField] private List<WindowBehavior> behaviors = new();

        [SerializeField] private GraphicRaycaster raycaster;
        [SerializeField] private Canvas viewCanvas;
        
        private IWindowNavigator _navigator;

        public WindowContext Context { get; private set; }

        public void Initialize(IWindowNavigator navigator)
        {
            _navigator = navigator;
            Context = new WindowContext();
            foreach (WindowBehavior windowBehavior in behaviors)
            {
                windowBehavior.Context = Context;
                windowBehavior.Window = this;
            }
        }

        public async UniTask Show()
        {
            foreach (WindowBehavior windowBehavior in behaviors)
            {
                await windowBehavior.Show();
            }
        }

        public async UniTask Close()
        {
            raycaster.enabled = false;
            foreach (WindowBehavior windowBehavior in behaviors)
            {
                await windowBehavior.Hide();
            }

            _navigator?.ProcessClose(this);
        }

        public T GetBehavior<T>() where T : WindowBehavior
        {
            foreach (WindowBehavior behavior in behaviors)
            {
                if (behavior is T typed)
                    return typed;
            }
            return null;
        }

        public void AddBehaviors(WindowBehavior[] toAdd)
        {
            behaviors.Clear();
            if (toAdd != null)
                behaviors.AddRange(toAdd);
        }
    }
}