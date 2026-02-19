using UnityEngine;

namespace App.Scripts.Libs.FancyScrollZenject.Placers
{
    /// <summary>
    /// Располагает элементы по дуге. Центральный элемент (position = 0.5) — в наивысшей точке по центру,
    /// остальные уходят вниз по дуге влево и вправо.
    /// </summary>
    public class MonoRadialPlacer : MonoPositionUpdater
    {
        [SerializeField]
        private SettingsRadialPlacer settings;

        [SerializeField]
        private RectTransform container;

        [SerializeField] private RectTransform viewport;
        
        private void Awake()
        {
            if (container == null)
                container = GetComponent<RectTransform>();
        }

        public override void UpdatePosition(float position)
        {
            if (container == null || settings == null)
                return;

            float radius = settings.Radius;
            float arcSpanDegrees = settings.ArcSpanDegrees;

            var viewportCenter = Vector2.zero;//viewport.rect.center;

            var rotateCenter = viewportCenter - new Vector2(0, radius);
            
            // position 0.5 = центр дуги (наивысшая точка), 0 и 1 = концы дуги внизу
            // Угол: 90° = вверх, 0° = вправо, 180° = влево
            float angleDeg = 90f + (0.5f - position) * arcSpanDegrees;
            float angleRad = angleDeg * Mathf.Deg2Rad;

            float x = rotateCenter.x + radius * Mathf.Cos(angleRad);
            float y = rotateCenter.y + radius * Mathf.Sin(angleRad);

            container.anchoredPosition = new Vector2(x, y);

            if (settings.ScaleByDistance)
            {
                float distanceFromCenter = Mathf.Abs(position - 0.5f) * 2f; // 0 в центре, 1 на краях
                float scale = Mathf.Lerp(1f, settings.MinScale, distanceFromCenter);
                container.localScale = Vector3.one * scale;
            }
        }
    }
}
