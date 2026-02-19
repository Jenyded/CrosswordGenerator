using App.Scripts.Features.Windows.WindowCrosswordGallery.ViewModels;
using App.Scripts.Libs.FancyScrollView.Sources.Runtime.Core;
using App.Scripts.Libs.FancyScrollZenject.Placers;
using TMPro;
using UnityEngine;

namespace App.Scripts.Features.Windows.WindowCrosswordGallery.ViewScrollCrosswords.Items
{
    public class ViewItemScrollCrossword : FancyCell<ViewModelCrosswordLevel, ContextScrollCrosswords>
    {
        [SerializeField] private MonoPositionUpdater positionUpdater;
        [SerializeField] private ViewCrossword viewCrossword;

        [SerializeField] private RectTransform crosswordContainer;
        [SerializeField] private TMP_Text labelQuality;
        

        public override void UpdateContent(ViewModelCrosswordLevel itemData)
        {
            viewCrossword.Setup(itemData.Level);
            UpdateQualityLabel(itemData);
            FitScaleInContainer();
        }

        private void UpdateQualityLabel(ViewModelCrosswordLevel itemData)
        {
            labelQuality.text = $"Quality: {itemData.Quality:00.00}";
        }

        private void FitScaleInContainer()
        {
            if (crosswordContainer == null)
                return;

            Vector2 size = viewCrossword.GetSize();
            if (size.x <= 0 || size.y <= 0)
                return;

            Rect rect = crosswordContainer.rect;
            float scaleX = rect.width / size.x;
            float scaleY = rect.height / size.y;
            float scale = Mathf.Min(scaleX, scaleY);

            viewCrossword.transform.localScale = new Vector3(scale, scale, 1f);
        }

        public override void UpdatePosition(float position)
        {
            positionUpdater.UpdatePosition(position);
        }
    }
}