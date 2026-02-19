using App.Scripts.Features.Crosswords.Core;
using UnityEngine;

namespace App.Scripts.Features.Crosswords.CrosswordQualityChecker.Checkers
{
    public class QualityCheckerCenterBias : ICrosswordQualityChecker
    {
        /// <summary>
        /// Оценка смещения к центру: чем ближе заполненные клетки к центру поля (по Манхеттенскому расстоянию), тем выше оценка. 0..1.
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

            float centerR = (height - 1) / 2f;
            float centerC = (width - 1) / 2f;
            float maxDistance = centerR + centerC;
            if (maxDistance <= 0f)
                return 1f;

            float sumScore = 0f;
            int filledCount = 0;

            for (int r = 0; r < height; r++)
            for (int c = 0; c < width; c++)
            {
                if (grid[r, c] == '\0')
                    continue;

                float distance = Mathf.Abs(r - centerR) + Mathf.Abs(c - centerC);
                float cellScore = 1f - distance / maxDistance;
                sumScore += Mathf.Clamp01(cellScore);
                filledCount++;
            }

            return filledCount > 0 ? sumScore / filledCount : 0f;
        }
    }
}
