using DG.Tweening;
using UnityEngine;

namespace App.Scripts.Features.Windows.Animations
{
    [CreateAssetMenu(fileName = "SettingsAnimationWindow", menuName = "App/Windows/Animation Window Settings", order = 0)]
    public class SettingsAnimationWindow : ScriptableObject
    {
        [SerializeField] private float showDuration = 0.25f;
        [SerializeField] private float hideDuration = 0.2f;
        [SerializeField] private float showScaleFrom = 0.95f;
        [SerializeField] private float hideScaleTo = 0.95f;
        [SerializeField] private Ease easeShow = Ease.OutBack;
        [SerializeField] private Ease easeHide = Ease.InBack;

        public float ShowDuration => showDuration;
        public float HideDuration => hideDuration;
        public float ShowScaleFrom => showScaleFrom;
        public float HideScaleTo => hideScaleTo;
        public Ease EaseShow => easeShow;
        public Ease EaseHide => easeHide;
    }
}
