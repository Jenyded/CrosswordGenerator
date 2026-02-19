using App.Scripts.Infrastructure.Values;
using UnityEngine;

namespace App.Scripts.Features.Crosswords.CrossWordGenerator.Models
{
    public class GenerationOptions
    {
        private Vector2Int _fieldSize;
        private MinMaxInt _worldCount;
        private MinMaxInt _wordCharCount;
        private int _maxInputCharCount;
        private float _desiredLevelQuality;
        private int _generationCount;

        /// <summary>
        /// размер поля для генерации
        /// </summary>
        public Vector2Int FieldSize
        {
            get => _fieldSize;
            set { _fieldSize = value; Validate(); }
        }

        /// <summary>
        /// минимальное и максимальное кол-во слов на поле
        /// </summary>
        public MinMaxInt WorldCount
        {
            get => _worldCount;
            set { _worldCount = value; Validate(); }
        }

        /// <summary>
        /// минимальное и максимальное кол-во букв в словах 
        /// </summary>
        public MinMaxInt WordCharCount
        {
            get => _wordCharCount;
            set { _wordCharCount = value; Validate(); }
        }

        /// <summary>
        /// максимальное кол-во символов в колесе ввода
        /// </summary>
        public int MaxInputCharCount
        {
            get => _maxInputCharCount;
            set { _maxInputCharCount = value; Validate(); }
        }

        /// <summary>
        /// ожидаемый уровень качества
        /// </summary>
        public float DesiredLevelQuality
        {
            get => _desiredLevelQuality;
            set { _desiredLevelQuality = value; Validate(); }
        }

        /// <summary>
        /// количество генераций
        /// </summary>
        public int GenerationCount
        {
            get => _generationCount;
            set { _generationCount = value; Validate(); }
        }

        protected virtual void Validate()
        {
            _fieldSize = new Vector2Int(Mathf.Max(1, _fieldSize.x), Mathf.Max(1, _fieldSize.y));
            _generationCount = Mathf.Max(1, _generationCount);
            _maxInputCharCount = Mathf.Max(1, _maxInputCharCount);
            _desiredLevelQuality = Mathf.Max(0f, _desiredLevelQuality);

            _worldCount.min = Mathf.Max(0, _worldCount.min);
            _worldCount.max = Mathf.Max(0, _worldCount.max);
            if (_worldCount.min > _worldCount.max)
                _worldCount.max = _worldCount.min;
      
            _wordCharCount.min = Mathf.Max(0, _wordCharCount.min);
            _wordCharCount.max = Mathf.Max(0, _wordCharCount.max);
            if (_wordCharCount.min > _wordCharCount.max)
                _wordCharCount.max = _wordCharCount.min;
        }

        public override string ToString()
        {
            return $"{nameof(GenerationOptions)}(FieldSize={FieldSize}, WorldCount={WorldCount}, WordCharCount={WordCharCount}, MaxInputCharCount={MaxInputCharCount}, DesiredLevelQuality={DesiredLevelQuality}, GenerationCount={GenerationCount})";
        }
    }
}