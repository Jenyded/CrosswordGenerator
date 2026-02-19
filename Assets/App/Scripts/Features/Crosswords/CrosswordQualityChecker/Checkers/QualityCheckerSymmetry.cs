using App.Scripts.Features.Crosswords.Core;

namespace App.Scripts.Features.Crosswords.CrosswordQualityChecker.Checkers
{
    public class QualityCheckerSymmetry : ICrosswordQualityChecker
    {
        /// <summary>
        /// Оценка симметрии: 0.5 за симметрию по горизонтали, 0.5 за симметрию по вертикали (макс. 1.0).
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
            float mark = 0f;

            if (HasHorizontalSymmetry(grid, width, height))
                mark += 0.5f;

            if (HasVerticalSymmetry(grid, width, height))
                mark += 0.5f;

            return mark;
        }

        private static bool HasHorizontalSymmetry(char[,] grid, int width, int height)
        {
            for (int r = 0; r < height / 2; r++)
            {
                int mirrorR = height - 1 - r;
                for (int c = 0; c < width; c++)
                {
                    bool filled = grid[r, c] != '\0';
                    bool mirrorFilled = grid[mirrorR, c] != '\0';
                    if (filled != mirrorFilled)
                        return false;
                }
            }
            return true;
        }

        private static bool HasVerticalSymmetry(char[,] grid, int width, int height)
        {
            for (int r = 0; r < height; r++)
            {
                for (int c = 0; c < width / 2; c++)
                {
                    int mirrorC = width - 1 - c;
                    bool filled = grid[r, c] != '\0';
                    bool mirrorFilled = grid[r, mirrorC] != '\0';
                    if (filled != mirrorFilled)
                        return false;
                }
            }
            return true;
        }
    }
}
