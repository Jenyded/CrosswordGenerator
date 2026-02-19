using System;
using System.Collections.Generic;
using UnityEngine;

namespace App.Scripts.Features.Crosswords.Core
{
    [Serializable]
    public class LevelCrosswordData
    {
        public string id;
        public Vector2Int size;

        public List<WordData> words = new();

        public override string ToString()
        {
            var wordsStr = words != null ? string.Join(", ", words) : "";
            return $"{nameof(LevelCrosswordData)}(id={id}, size={size}, words=[{wordsStr}])";
        }
    }

    [Serializable]
    public class WordData
    {
        public string word;
        public int gridIndex;
        public bool isVertical;

        public override string ToString()
        {
            return $"{word}({gridIndex}, {(isVertical ? "v" : "h")})";
        }
    }
}