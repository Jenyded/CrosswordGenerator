using System;

namespace App.Scripts.Infrastructure.Values
{
    [Serializable]
    public struct MinMaxInt
    {
        public int min;
        public int max;

        public override string ToString()
        {
            return $"{nameof(MinMaxInt)}(min={min}, max={max})";
        }
    }
}