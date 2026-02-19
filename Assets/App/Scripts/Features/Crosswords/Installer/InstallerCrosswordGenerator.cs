using App.Scripts.Features.Crosswords.CrosswordGallery;
using App.Scripts.Features.Crosswords.CrossWordGenerator.Config;
using App.Scripts.Features.Crosswords.CrossWordGenerator.Services.Generator;
using App.Scripts.Features.Crosswords.CrosswordQualityChecker;
using App.Scripts.Features.Crosswords.CrosswordQualityChecker.Checkers;
using App.Scripts.Features.Crosswords.CrosswordQualityChecker.Config;
using App.Scripts.Features.Crosswords.CrosswordQualityChecker.Container;
using Zenject;

namespace App.Scripts.Features.Crosswords.Installer
{
    public class InstallerCrosswordGenerator : Installer<SettingsStaticGenerator, SettingsCrosswordQualityWeights, InstallerCrosswordGenerator>
    {
        private readonly SettingsStaticGenerator _settingsDummyGenerator;
        private readonly SettingsCrosswordQualityWeights _settingsQualityWeights;

        public InstallerCrosswordGenerator(SettingsStaticGenerator settingsDummyGenerator, SettingsCrosswordQualityWeights settingsQualityWeights)
        {
            _settingsDummyGenerator = settingsDummyGenerator;
            _settingsQualityWeights = settingsQualityWeights;
        }
        
        public override void InstallBindings()
        {
            Container.Bind<ICrosswordGenerateOptionsProvider>().To<CrosswordOptionProvider>().AsSingle();
            Container.Bind<ICrosswordGalleryHolder>().To<CrosswordGalleryHolder>().AsSingle();

            Container.Bind<SettingsStaticGenerator>()
                .FromInstance(_settingsDummyGenerator)
                .AsSingle();
            Container.Bind<ICrosswordGenerator>()
                .To<CrosswordGeneratorStatic>()
                .AsSingle();
            
            InstallChecker();
        }

        private void InstallChecker()
        {
            Container.Bind<ICrosswordQualityChecker>()
                .To<CrosswordQuailityCheckerContainer>()
                .FromSubContainerResolve()
                .ByMethod(SetupChecker)
                .AsSingle()
                .WhenNotInjectedInto<CrosswordQuailityCheckerContainer>();
            
        }

        private void SetupChecker(DiContainer subContainer)
        {
            subContainer.Bind<SettingsCrosswordQualityWeights>()
                .FromInstance(_settingsQualityWeights)
                .AsSingle();

            subContainer.Bind<CrosswordQuailityCheckerContainer>()
                .To<CrosswordQuailityCheckerContainer>()
                .AsCached()
                .WhenNotInjectedInto<CrosswordQuailityCheckerContainer>();

            BindChecker<CrosswordQuailityIntersections>(subContainer, KeysQualityCheckers.CrosswordQuailityIntersections);
            BindChecker<QualityCheckerDensity>(subContainer, KeysQualityCheckers.QualityCheckerDensity);
            BindChecker<QualityCheckerSymmetry>(subContainer, KeysQualityCheckers.QualityCheckerSymmetry);
            BindChecker<QualityCheckerCenterBias>(subContainer, KeysQualityCheckers.QualityCheckerCenterBias);
            BindChecker<QualityCheckerDirectionBalance>(subContainer, KeysQualityCheckers.QualityCheckerDirectionBalance);
        }

        private static void BindChecker<T>(DiContainer subContainer, string key) where T : ICrosswordQualityChecker
        {
            subContainer.Bind<IKeyQualityChecker>()
                .To<KeyQualityChecker<T>>()
                .AsCached()
                .WithArguments(key);

            subContainer.Bind<T>().To<T>().AsSingle();
        }
    }
}