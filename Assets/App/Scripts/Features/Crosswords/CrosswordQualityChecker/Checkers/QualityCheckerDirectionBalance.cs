using App.Scripts.Features.Crosswords.Core;

namespace App.Scripts.Features.Crosswords.CrosswordQualityChecker.Checkers
{
    /// <summary>
    /// Баланс направлений: 1 − |hCells − vCells| / totalOccupied.
    /// Идеал (50/50) → 1, все слова в одном направлении → 0.
    /// </summary>
    public class QualityCheckerDirectionBalance : ICrosswordQualityChecker
    {
        public float GetMark(LevelCrosswordData crosswordData)
        {
            if (crosswordData?.words == null || crosswordData.words.Count == 0)
                return 0f;

            int width = crosswordData.size.x;
            int height = crosswordData.size.y;
            if (width <= 0 || height <= 0)
                return 0f;

            int horizontalCells = 0;
            int verticalCells = 0;

            foreach (var wordData in crosswordData.words)
            {
                if (string.IsNullOrEmpty(wordData.word))
                    continue;

                if (wordData.isVertical)
                    verticalCells += wordData.word.Length;
                else
                    horizontalCells += wordData.word.Length;
            }

            int total = horizontalCells + verticalCells;
            if (total == 0)
                return 0f;

            int diff = horizontalCells > verticalCells
                ? horizontalCells - verticalCells
                : verticalCells - horizontalCells;

            return 1f - (float)diff / total;
        }
    }
}
