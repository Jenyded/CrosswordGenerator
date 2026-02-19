using App.Scripts.Features.Windows.WindowCrosswordGallery.ViewModels;
using App.Scripts.Features.Windows.WindowCrosswordGallery.ViewScrollCrosswords;
using App.Scripts.Infrastructure.SimpleWindows;
using App.Scripts.Infrastructure.SimpleWindows.Window;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace App.Scripts.Features.Windows.WindowCrosswordGallery.Behavior
{
    public class WindowCrosswordGallery : WindowBehavior
    {
        [SerializeField] private ViewScrollCrosswordsFancy viewSroll;
        
        public override UniTask Show()
        {
            if (Context.TryGet<ViewModelCrosswordGallery>(out var model) is false)
            {
                return UniTask.CompletedTask;
            }
            
            viewSroll.UpdateItems(model.Crosswords);
            return base.Show();
        }
    }
}