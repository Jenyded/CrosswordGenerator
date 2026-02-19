using App.Scripts.Infrastructure.SimpleWindows.Config;
using UnityEngine;
using Zenject;

namespace App.Scripts.Infrastructure.SimpleWindows.Installer
{
    public class DialogNavigatorInstaller : MonoInstaller
    {
        [SerializeField] private DialogConfig dialogConfig;
        [SerializeField] private WindowViewContainer windowViewContainerPrefab;

        public override void InstallBindings()
        {
            Container.Bind<WindowViewContainer>()
                .FromMethod(x =>
                {
                    var container = x.Container.InstantiatePrefabForComponent<WindowViewContainer>(windowViewContainerPrefab);
                    container.transform.SetParent(null);
                    return container;
                })
                .AsSingle();

            Container.Bind<IWindowNavigator>()
                .To<WindowNavigatorZenject>()
                .AsSingle()
                .WithArguments(dialogConfig);
        }
    }
}
