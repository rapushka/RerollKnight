using Code.Component;
using Entitas.Generic;
using UnityEngine;

namespace Code
{
	public class DestroyedWithDeathAnimationView : DestroyedView
	{
		[SerializeField] private Animator _animator;
		[SerializeField] private AnimationClip _deathAnimation;

		private bool _isDestroyed;

		public override void OnValueChanged(Entity<GameScope> entity, Destroyed component)
		{
			_animator.Play(_deathAnimation.name);
			_isDestroyed = entity.Is<Destroyed>();
		}

		public void OnAnimationEnd()
		{
			if (_isDestroyed)
				base.OnValueChanged(Entity, Entity?.GetOrDefault<Destroyed>());
		}
	}
}