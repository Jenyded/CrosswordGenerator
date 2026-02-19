namespace App.Scripts.Features.Crosswords.Core
{
    public static class ExtensionsCrosswordData
    {
        public static char[,] BuildLetterGrid(this LevelCrosswordData itemData)
        {
            var height = itemData.size.y;
            var width = itemData.size.x;
            
            var grid = new char[height, width];
            for (int r = 0; r < height; r++)
            for (int c = 0; c < width; c++)
                grid[r, c] = '\0';

            foreach (var wordData in itemData.words)
            {
                if (string.IsNullOrEmpty(wordData.word))
                    continue;

                int row = wordData.gridIndex / width;
                int col = wordData.gridIndex % width;

                foreach (char ch in wordData.word)
                {
                    if (row >= 0 && row < height && col >= 0 && col < width)
                        grid[row, col] = ch;

                    if (wordData.isVertical)
                        row++;
                    else
                        col++;
                }
            }

            return grid;
        }
    }
}