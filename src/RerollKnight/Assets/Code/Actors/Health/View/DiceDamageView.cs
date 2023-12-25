using Code.Component;
using DG.Tweening;
using Entitas.Generic;
using UnityEngine;

namespace Code
{
	public class DiceDamageView : BaseListener<GameScope, Health>
	{
		[SerializeField] private Transform _transform;
		[SerializeField] private float _duration = 0.2f;
		[SerializeField] private float _strength = 0.25f;
		[SerializeField] private int _vibrato = 100;

		private IViewConfig _viewConfig;

		private int _previousHealth;

		public override void OnValueChanged(Entity<GameScope> entity, Health component)
		{
			if (component.Value < _previousHealth)
				_transform.DOShakePosition(_duration, _strength, _vibrato);

			_previousHealth = component.Value;
		}
	}
}