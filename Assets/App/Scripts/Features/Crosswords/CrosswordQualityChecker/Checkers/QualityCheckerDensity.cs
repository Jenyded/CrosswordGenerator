using App.Scripts.Features.Crosswords.Core;

namespace App.Scripts.Features.Crosswords.CrosswordQualityChecker.Checkers
{
    public class QualityCheckerDensity : ICrosswordQualityChecker
    {
        /// <summary>
        /// Оценка плотности: доля заполненных клеток от общего числа клеток поля.
        /// Возвращает значение от 0 до 1.
        /// </summary>
        public float GetMark(LevelCrosswordData crosswordData)
        {
            if (crosswordData == null)
                return 0f;

            int width = crosswordData.size.x;
            int height = crosswordData.size.y;
            if (width <= 0 || height <= 0)
                return 0f;

            var grid = crosswordData.BuildLetterGrid();
            int totalCells = width * height;
            int filledCount = 0;

            for (int r = 0; r < height; r++)
            for (int c = 0; c < width; c++)
                if (grid[r, c] != '\0')
                    filledCount++;

            return (float)filledCount / totalCells;
        }
    }
}
