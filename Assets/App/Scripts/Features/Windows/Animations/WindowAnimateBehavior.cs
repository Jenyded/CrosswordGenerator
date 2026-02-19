using App.Scripts.Infrastructure.SimpleWindows;
using App.Scripts.Infrastructure.SimpleWindows.Window;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

namespace App.Scripts.Features.Windows.Animations
{
    public class WindowAnimateBehavior : WindowBehavior
    {
        [SerializeField] private SettingsAnimationWindow settings;
        [SerializeField] private RectTransform targetRectTransform;
        [SerializeField] private CanvasGroup targetCanvasGroup;

        private Sequence _currentSequence;

        private void ClearCurrentSequence()
        {
            if (_currentSequence != null && _currentSequence.IsActive())
                _currentSequence.Kill(true);
            _currentSequence = null;
        }

        public override async UniTask Show()
        {
            ClearCurrentSequence();

            if (targetRectTransform != null)
                targetRectTransform.localScale = Vector3.one * settings.ShowScaleFrom;
            targetCanvasGroup.alpha = 0f;

            _currentSequence = DOTween.Sequence();

            if (targetRectTransform != null)
            {
                _currentSequence.Join(targetRectTransform
                    .DOScale(Vector3.one, settings.ShowDuration)
                    .SetEase(settings.EaseShow));
            }

            _currentSequence.Join(targetCanvasGroup
                .DOFade(1f, settings.ShowDuration)
                .SetEase(Ease.Linear));

            await _currentSequence.AsyncWaitForCompletion().AsUniTask();
        }

        public override async UniTask Hide()
        {
            ClearCurrentSequence();

            _currentSequence = DOTween.Sequence();

            if (targetRectTransform != null)
            {
                _currentSequence.Join(targetRectTransform
                    .DOScale(Vector3.one * settings.HideScaleTo, settings.HideDuration)
                    .SetEase(settings.EaseHide));
            }

            _currentSequence.Join(targetCanvasGroup
                .DOFade(0f, settings.HideDuration)
                .SetEase(Ease.Linear));

            await _currentSequence.AsyncWaitForCompletion().AsUniTask();
        }
    }
}