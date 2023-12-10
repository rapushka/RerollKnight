using Code.Component;
using Entitas.Generic;
using UnityEngine;

namespace Code
{
	public class RotationView : BaseListener<GameScope, Rotation>
	{
		[SerializeField] private Transform _transform;

		public override void OnValueChanged(Entity<GameScope> entity, Rotation component)
		{
			if (!entity.Is<Detached>())
				_transform.rotation = component.Value;
		}
	}
}