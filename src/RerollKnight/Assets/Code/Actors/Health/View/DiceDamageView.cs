using cakeslice;
using Code.Component;
using DG.Tweening;
using Entitas.Generic;
using UnityEngine;

namespace Code
{
	public class DiceDamageView : BaseListener<GameScope, Health>
	{
		[SerializeField] private Transform _transform;
		[SerializeField] private Outline _outline;

		[Header("Tweaks")]
		[SerializeField] private float _duration = 0.2f;
		[SerializeField] private float _strength = 0.25f;
		[SerializeField] private int _vibrato = 100;

		private int _previousHealth;
		private Sequence _sequence;

		public override void OnValueChanged(Entity<GameScope> entity, Health component)
		{
			if (component.Value < _previousHealth)
			{
				_sequence?.Kill();

				_outline.enabled = true;
				_outline.color = (int)TargetState.Wrong;

				_sequence = DOTween.Sequence()
				                   .Append(_transform.DOShakePosition(_duration, _strength, _vibrato))
				                   .AppendCallback(() => _outline.enabled = false);
			}

			_previousHealth = component.Value;
		}
	}
}