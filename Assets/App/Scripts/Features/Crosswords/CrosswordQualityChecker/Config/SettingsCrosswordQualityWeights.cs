using System;
using UnityEngine;

namespace App.Scripts.Features.Crosswords.CrosswordQualityChecker.Config
{
    [Serializable]
    public struct CrosswordQualityWeightEntry
    {
        [SerializeField] private string key;
        [SerializeField] private float value;

        public string Key => key;
        public float Value => value;
    }

    public class SettingsCrosswordQualityWeights : ScriptableObject
    {
        [SerializeField]
        [Tooltip("Веса критериев качества кроссворда: ключ — идентификатор критерия, значение — вес")]
        private CrosswordQualityWeightEntry[] weights = Array.Empty<CrosswordQualityWeightEntry>();

        public CrosswordQualityWeightEntry[] Weights => weights;

        /// <summary>
        /// Пытается получить вес по ключу. Возвращает true и записывает вес в <paramref name="weight"/>, если ключ найден.
        /// </summary>
        public bool TryGetWeight(string key, out float weight)
        {
            weight = 0f;
            if (string.IsNullOrEmpty(key) || weights == null)
                return false;

            for (int i = 0; i < weights.Length; i++)
            {
                if (weights[i].Key == key)
                {
                    weight = weights[i].Value;
                    return true;
                }
            }

            return false;
        }
    }
}