using App.Scripts.Features.AppStates;
using Zenject;

namespace App.Scripts.Bootstrap.EntryPoint
{
    public class InstallerEntryPoint : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<AppEntryPoint<StateInitializeApp>>().AsSingle();
        }
    }
}