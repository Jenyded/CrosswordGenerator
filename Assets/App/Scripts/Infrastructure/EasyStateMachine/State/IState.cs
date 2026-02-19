using Cysharp.Threading.Tasks;

namespace App.Scripts.Infrastructure.EasyStateMachine.State
{
    public interface IState
    {
        IStateMachine StateMachine { get; set; }
        
        UniTask OnEnter();
        UniTask OnExit();

        void Update(float dt);
    }
}