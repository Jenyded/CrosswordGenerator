using App.Scripts.Features.Windows.WindowCrosswordGallery.ViewScrollCrosswords;
using App.Scripts.Features.Windows.WindowCrosswordGallery.ViewScrollCrosswords.Items;
using App.Scripts.Infrastructure.SimplePool;
using UnityEngine;
using Zenject;

namespace App.Scripts.Bootstrap.Installers
{
    public class InstallerViewPools : MonoInstaller
    {
        [SerializeField] private ViewItemCrosswordCell prefabViewCell;

        [SerializeField] private Transform poolContainer;
        
        public override void InstallBindings()
        {
            Container.Bind(typeof(ISimplePool), typeof(ISimplePool<ViewItemCrosswordCell>))
                .To<SimplePrefabPool<ViewItemCrosswordCell>>()
                .AsSingle()
                .WithArguments(prefabViewCell, 20, poolContainer);
        }
    }
}