using System.Collections.Generic;
using App.Scripts.Features.Crosswords.Core;
using App.Scripts.Features.Crosswords.CrossWordGenerator.Config;
using App.Scripts.Features.Crosswords.CrossWordGenerator.Models;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace App.Scripts.Features.Crosswords.CrossWordGenerator.Services.Generator
{
    public class CrosswordGeneratorStatic : ICrosswordGenerator
    {
        private readonly SettingsStaticGenerator _settings;

        public CrosswordGeneratorStatic(SettingsStaticGenerator settings)
        {
            _settings = settings;
        }

        public UniTask<List<LevelCrosswordData>> Generate(GenerationOptions options)
        {
            var result = LoadLevelsFromResources();
            return UniTask.FromResult(result);
        }

        private List<LevelCrosswordData> LoadLevelsFromResources()
        {
            var result = new List<LevelCrosswordData>();
            var path = _settings.LevelsResourcePath;

            if (string.IsNullOrEmpty(path))
                return result;

            var textAssets = Resources.LoadAll<TextAsset>(path);

            foreach (var textAsset in textAssets)
            {
                if (textAsset == null || string.IsNullOrEmpty(textAsset.text))
                    continue;

                var level = JsonUtility.FromJson<LevelCrosswordData>(textAsset.text);
                if (level != null)
                    result.Add(level);
            }

            return result;
        }
    }
}
