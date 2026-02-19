using App.Scripts.Features.Commands.Gallery;
using App.Scripts.Features.Commands.Generate;
using App.Scripts.Features.Commands.PrepareGame;
using App.Scripts.Features.Crosswords.Commands;
using Zenject;

namespace App.Scripts.Features.Commands.Installer
{
    public class InstallerAppCommand : Installer<InstallerAppCommand>
    {
        public override void InstallBindings()
        {
            Container.Bind<ICommandNavigateToMenu>().To<CommandNavigateToPrepare>().AsSingle();
            Container.Bind<IRouterCreateSettings>().To<RouterCreateViewSettings>().AsSingle();
            Container.Bind<IRouterShowCrosswordGallery>().To<RouterShowCrosswordGallery>().AsSingle();
            Container.Bind<ICommandProcessGenerateCrossword>().To<CommandProcessGenerateCrossword>().AsSingle();
            Container.Bind<ICommandStartGenerateFactory>().To<CommandStartGenerateFactory>().AsSingle();
        }
    }
}