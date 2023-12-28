using DG.Tweening;
using UnityEngine;

namespace Code
{
	public class LoadingCurtain : WindowBase
	{
		[SerializeField] private CanvasGroup _canvasGroup;
		[SerializeField] private float _duration;

		protected override void OnShow()
		{
			ShowImmediately();
		}

		public void FadeIn() => SetFade(true, _duration);

		public void FadeOut() => SetFade(false, _duration);

		public void ShowImmediately() => SetFade(true, 0f);

		public void HideImmediately() => SetFade(false, 0f);

		private void SetFade(bool value, float duration) => _canvasGroup.DOFade(value.ToFloat(), duration);
	}
}