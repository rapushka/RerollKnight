using Code.Component;
using Entitas.Generic;
using UnityEngine;

namespace Code
{
	public class LocalRotationView : BaseListener<GameScope, Rotation>
	{
		[SerializeField] private Transform _transform;

		public override void OnValueChanged(Entity<GameScope> entity, Rotation component)
		{
			_transform.localRotation = component.Value;
		}
	}
}