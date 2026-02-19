using UnityEngine;

namespace App.Scripts.Libs.FancyScrollZenject.Placers
{
    public class SettingsRadialPlacer : ScriptableObject
    {
        [SerializeField]
        [Tooltip("Радиус дуги в единицах RectTransform (обычно пиксели)")]
        private float radius = 400f;

        [SerializeField]
        [Tooltip("Угол дуги в градусах (полная дуга = 180°)")]
        [Range(30f, 180f)]
        private float arcSpanDegrees = 120f;

        [SerializeField]
        [Tooltip("Масштабировать элемент по удалению от центра (1 = без масштаба)")]
        private bool scaleByDistance;

        [SerializeField]
        [Tooltip("Минимальный масштаб для крайних элементов (при scaleByDistance = true)")]
        [Range(0.1f, 1f)]
        private float minScale = 0.7f;

        public float Radius => radius;
        public float ArcSpanDegrees => arcSpanDegrees;
        public bool ScaleByDistance => scaleByDistance;
        public float MinScale => minScale;
    }
}
