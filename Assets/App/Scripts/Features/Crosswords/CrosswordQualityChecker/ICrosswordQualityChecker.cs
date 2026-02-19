using App.Scripts.Features.Crosswords.Core;

namespace App.Scripts.Features.Crosswords.CrosswordQualityChecker
{
    public interface ICrosswordQualityChecker
    {
        float GetMark(LevelCrosswordData crosswordData);
    }
}