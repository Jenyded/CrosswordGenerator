using System.Collections.Generic;
using App.Scripts.Features.Crosswords.Core;

namespace App.Scripts.Features.Crosswords.CrosswordGallery
{
    public class CrosswordGalleryHolder : ICrosswordGalleryHolder
    {
        private readonly List<LevelCrosswordData> _crosswords = new();

        public IEnumerable<LevelCrosswordData> Crosswords => _crosswords;
        
        public void Setup(IEnumerable<LevelCrosswordData> crosswords)
        {
            Clear();
            _crosswords.AddRange(crosswords);
        }

        public void Clear()
        {
            _crosswords.Clear();
        }
    }
}