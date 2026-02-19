using App.Scripts.Features.Crosswords.Core;

namespace App.Scripts.Features.Crosswords.CrosswordQualityChecker.Checkers
{
    public class CrosswordQuailityIntersections : ICrosswordQualityChecker
    {
        /// <summary>
        /// Оценка качества: доля занятых клеток, в которых пересекаются слова (2+ слов на клетку).
        /// Возвращает значение от 0 до 1.
        /// </summary>
        public float GetMark(LevelCrosswordData crosswordData)
        {
            if (crosswordData?.words == null || crosswordData.words.Count == 0)
                return 0f;

            int width = crosswordData.size.x;
            int height = crosswordData.size.y;
            if (width <= 0 || height <= 0)
                return 0f;

            var cellWordCount = new int[height, width];

            foreach (var wordData in crosswordData.words)
            {
                if (string.IsNullOrEmpty(wordData.word))
                    continue;

                int row = wordData.gridIndex / width;
                int col = wordData.gridIndex % width;

                foreach (char ch in wordData.word)
                {
                    if (row >= 0 && row < height && col >= 0 && col < width)
                        cellWordCount[row, col]++;

                    if (wordData.isVertical)
                        row++;
                    else
                        col++;
                }
            }

            int occupiedCells = 0;
            int intersectionCells = 0;

            for (int r = 0; r < height; r++)
            for (int c = 0; c < width; c++)
            {
                int count = cellWordCount[r, c];
                if (count >= 1) occupiedCells++;
                if (count >= 2) intersectionCells++;
            }

            if (occupiedCells == 0)
                return 0f;

            return (float)intersectionCells / occupiedCells;
        }
    }
}