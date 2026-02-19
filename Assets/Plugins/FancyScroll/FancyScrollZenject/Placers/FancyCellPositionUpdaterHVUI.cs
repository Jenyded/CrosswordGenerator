using UnityEngine;

namespace App.Scripts.Libs.FancyScrollZenject.Placers
{
    public class FancyCellPositionUpdaterHVUI : MonoPositionUpdater
    {
        [SerializeField]
        private RectTransform ViewportCell;

        [SerializeField]
        private RectTransform Container;

        [SerializeField] private Orientation orientation;
        
        private enum Orientation
        {
            Vertical,
            Horizontal
        }

        private Vector2 Direction
        {
            get
            {
                if (orientation == Orientation.Vertical)
                {
                    return Vector2.down;
                }
                
                return Vector2.right;
            }
        }
        
        public override void UpdatePosition(float position)
        {
            var containerSize = ViewportCell.rect.size;
            var itemSize = Container.rect.size;
            var deltaSize = containerSize + itemSize;

            var direction = Direction;
            var startOffset = (- containerSize * 0.5f - itemSize * Container.pivot) * direction;
            Container.anchoredPosition = startOffset + deltaSize * position * direction;
        }
    }
}