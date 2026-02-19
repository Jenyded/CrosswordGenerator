using App.Scripts.Features.Crosswords.CrossWordGenerator.Config;
using App.Scripts.Features.Crosswords.CrosswordQualityChecker;
using App.Scripts.Features.Crosswords.CrosswordQualityChecker.Config;
using App.Scripts.Features.Crosswords.Installer;
using UnityEngine;
using Zenject;

namespace App.Scripts.Bootstrap.Installers
{
    public class InstallerAppServices : MonoInstaller
    {
        [SerializeField] private SettingsStaticGenerator settingsStaticGenerator;
        [SerializeField] private SettingsCrosswordQualityWeights settingsQualityWeights;

        public override void InstallBindings()
        {
            InstallerServices.Install(Container);
            InstallerCrosswordGenerator.Install(Container, settingsStaticGenerator, settingsQualityWeights);
        }
    }
}