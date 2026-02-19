using Cysharp.Threading.Tasks;

namespace App.Scripts.Infrastructure.EasyStateMachine.State
{
    public abstract class BaseState : IState
    {
        public IStateMachine StateMachine { get; set; }
        public virtual UniTask OnEnter() => UniTask.CompletedTask;

        public virtual UniTask OnExit() => UniTask.CompletedTask;

        public virtual void Update(float dt) { }
    }
}
