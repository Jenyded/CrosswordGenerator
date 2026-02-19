using System.Collections.Generic;
using App.Scripts.Features.Crosswords.Core;

namespace App.Scripts.Features.Crosswords.CrosswordGallery
{
    public interface ICrosswordGalleryHolder
    {
        IEnumerable<LevelCrosswordData> Crosswords { get; }
        
        void Setup(IEnumerable<LevelCrosswordData> crosswords);

        void Clear();
    }
}