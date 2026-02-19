using Cysharp.Threading.Tasks;
using UnityEngine;

namespace App.Scripts.Infrastructure.SimpleWindows.Window
{
    public class WindowBehavior : MonoBehaviour
    {
        public WindowContext Context { get; set; }
        public WindowView Window { get; set; }

        public virtual UniTask Show()
        {
            return UniTask.CompletedTask;
        }

        public virtual UniTask Hide()
        {
            return UniTask.CompletedTask;
        }
    }
}