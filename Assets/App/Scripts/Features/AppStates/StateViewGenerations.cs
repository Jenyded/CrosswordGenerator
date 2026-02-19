using App.Scripts.Features.Commands.Gallery;
using App.Scripts.Infrastructure.EasyStateMachine.State;
using App.Scripts.Infrastructure.SimpleWindows;
using App.Scripts.Infrastructure.SimpleWindows.Window;
using Cysharp.Threading.Tasks;

namespace App.Scripts.Features.AppStates
{
    public class StateViewGenerations : BaseState
    {
        private readonly IRouterShowCrosswordGallery _routerShowCrosswordGallery;
        private WindowView _window;

        public StateViewGenerations(
            IRouterShowCrosswordGallery routerShowCrosswordGallery)
        {
            _routerShowCrosswordGallery = routerShowCrosswordGallery;
        }

        public override async UniTask OnEnter()
        {
            _window = _routerShowCrosswordGallery.Create();
            await _window.Show();
        }

        public override async UniTask OnExit()
        {
            await _window.Close();
        }
    }
}