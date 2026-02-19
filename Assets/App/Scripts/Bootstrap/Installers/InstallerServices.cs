using App.Scripts.Features.Commands.Installer;
using App.Scripts.Features.Windows.WindowSettings.Provider;
using App.Scripts.Infrastructure.EasyStateMachine;
using App.Scripts.Infrastructure.EasyStateMachine.State;
using App.Scripts.Infrastructure.Logger.installer;
using Zenject;

namespace App.Scripts.Bootstrap.Installers
{
    public class InstallerServices : Installer<InstallerServices>
    {
        public override void InstallBindings()
        {
            InstallerLogger.Install(Container);
            InstallerAppCommand.Install(Container);
            
            InstallStateMachine();
            InstallDialogSettings();
        }

        private void InstallDialogSettings()
        {
            Container.Bind<IProviderViewModelDialogSettings>().To<ProviderViewModelDialogSettings>().AsSingle();
        }

        private void InstallStateMachine()
        {
            Container.Bind<IStateMachine>().To<StateMachine>().AsSingle();
            Container.Bind<IFactoryState>().To<FactoryStateZenject>().AsSingle();
        }
    }
}