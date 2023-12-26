using Entitas.Generic;
using UnityEngine;

namespace Code.Component
{
	public class AnimationView : BaseListener<GameScope, PlayAnimation>
	{
		[SerializeField] private Animation _animation;
		[SerializeField] private AnimationClip _idleClip;

		public override void OnValueChanged(Entity<GameScope> entity, PlayAnimation component)
		{
			Play(component.Value);
		}

		public void OnAnimationEnd()
		{
			Debug.Log(nameof(OnAnimationEnd));
			Play(_idleClip);
		}

		private void Play(AnimationClip clip)
		{
			_animation.clip = clip;
			_animation.Play();
		}
	}
}