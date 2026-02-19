using App.Scripts.Features.Crosswords.Core;
using App.Scripts.Features.Crosswords.CrosswordQualityChecker.Config;
using App.Scripts.Infrastructure.Logger.Interfaces;

namespace App.Scripts.Features.Crosswords.CrosswordQualityChecker.Container
{
    public class CrosswordQuailityCheckerContainer : ICrosswordQualityChecker
    {
        private readonly SettingsCrosswordQualityWeights _weights;
        private readonly IKeyQualityChecker[] _checkers;
        private readonly IAppLogger _logger;

        public CrosswordQuailityCheckerContainer(SettingsCrosswordQualityWeights weights, 
            IKeyQualityChecker[] checkers, 
            IAppLogger logger)
        {
            _weights = weights;
            _checkers = checkers;
            _logger = logger;
        }

        public float GetMark(LevelCrosswordData crosswordData)
        {
            float sum = 0f;

            foreach (IKeyQualityChecker keyQualityChecker in _checkers)
            {
                var weight = GetWeight(keyQualityChecker);
                sum += keyQualityChecker.Checker.GetMark(crosswordData) * weight;
            }

            return sum;
        }

        private float GetWeight(IKeyQualityChecker keyQualityChecker)
        {
            string checkerKey = keyQualityChecker.Key;
            if (_weights.TryGetWeight(checkerKey, out float weight) is false)
            {
                weight = 1;
                _logger.Log($"cant find weight for {checkerKey}");
            }

            return weight;
        }
    }
}