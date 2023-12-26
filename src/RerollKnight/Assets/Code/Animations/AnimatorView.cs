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
			Play(component.Value);
			entity.Remove<PlayAnimation>(); // TODO: wouldn't it break iteration? 
		}

		public void OnAnimationEnd()
		{
			Debug.Log(nameof(OnAnimationEnd));
			Play(_idleClip);
		}

		private void Play(AnimationClip clip)
		{
			_animator.Play(clip.name);
		}
	}
}