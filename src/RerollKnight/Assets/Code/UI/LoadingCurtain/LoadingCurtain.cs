using DG.Tweening;
using UnityEngine;

namespace Code
{
	public class LoadingCurtain : WindowBase
	{
		[SerializeField] private CanvasGroup _canvasGroup;
		[SerializeField] private float _duration;
		[SerializeField] private float _additionalWaiting;

		private Sequence _sequence;

		protected override void OnShow()
		{
			ShowImmediately();
		}

		public void FadeIn() => SetFade(true, _duration);

		public void FadeOut() => SetFade(false, _duration);

		public void ShowImmediately() => SetFade(true, 0f);

		public void HideImmediately() => SetFade(false, 0f);

		private void SetFade(bool value, float duration)
		{
			_sequence?.Kill();

			if (value)
			{
				_sequence = DOTween.Sequence()
					.Append(_canvasGroup.DOFade(1f, duration));
			}
			else
			{
				_sequence = DOTween.Sequence()
					.AppendInterval(_additionalWaiting)
					.Append(_canvasGroup.DOFade(0f, duration))
					.AppendCallback(Hide);
			}
		}
	}
}