using App.Scripts.Infrastructure.Logger.Core;
using App.Scripts.Infrastructure.Logger.Interfaces;
using Zenject;

namespace App.Scripts.Infrastructure.Logger.installer
{
    public class InstallerLogger : Installer<InstallerLogger>
    {
        public override void InstallBindings()
        {
            Container.Bind<ILoggerProvider>().To<LoggerProvider>().AsSingle();
            Container.Bind<ILogProcessor>().To<LogProcessorConsole>().AsSingle();

            Container.Bind<IAppLogger>().FromMethod((injectContext) =>
            {
                var logerProvider = injectContext.Container.Resolve<ILoggerProvider>();
                return logerProvider.CreateLogger(injectContext.ObjectType.Name);
            }).AsTransient();
        }
    }
}