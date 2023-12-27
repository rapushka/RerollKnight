using Code.Component;
using Entitas.Generic;
using UnityEngine;

namespace Code
{
	public class AnimatorView : BaseListener<GameScope, PlayAnimation>
	{
		[SerializeField] private Animator _animator;
		[SerializeField] private AnimationClip _idleClip;

		public override void OnValueChanged(Entity<GameScope> entity, PlayAnimation component)
		{
			Entity.Is<AnimationPrepared>(false);
			Play(component.Value);
			Entity.Is<AnimationEnded>(false);
		}

		public void OnAnimationPrepared()
		{
			Entity.Is<AnimationPrepared>(true);
		}

		public void OnAnimationEnd()
		{
			if (!Entity.isEnabled)
				return;

			Play(_idleClip);
			Entity.Remove<PlayAnimation>();
			Entity.Is<AnimationPrepared>(false);
			Entity.Is<AnimationEnded>(true);

			// Item
			Entity.RemoveSafety<HoldingItem>();
		}

		private void Play(AnimationClip clip)
		{
			_animator.Play(clip.name);
		}
	}
}