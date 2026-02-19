using App.Scripts.Features.Commands.PrepareGame;
using App.Scripts.Infrastructure.EasyStateMachine.State;
using App.Scripts.Infrastructure.SimpleWindows;
using App.Scripts.Infrastructure.SimpleWindows.Window;
using Cysharp.Threading.Tasks;

namespace App.Scripts.Features.AppStates
{
    public class StatePrepareGeneration : BaseState
    {
        private readonly IRouterCreateSettings _router;
        private WindowView _window;

        public StatePrepareGeneration(IRouterCreateSettings router)
        {
            _router = router;
        }
        
        public override async UniTask OnEnter()
        {
            _window = _router.Create();
            await _window.Show();
        }

        public override async UniTask OnExit()
        {
            await CloseWindow();
        }

        private async UniTask CloseWindow()
        {
            if (_window is null)
            {
                return;
            }

            await _window.Close();
        }
    }
}