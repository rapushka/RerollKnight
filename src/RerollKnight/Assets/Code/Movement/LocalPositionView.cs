using Code.Component;
using Entitas.Generic;
using UnityEngine;

namespace Code
{
	public class LocalPositionView : BaseListener<GameScope, Position>
	{
		[SerializeField] private Transform _transform;

		public override void OnValueChanged(Entity<GameScope> entity, Position component)
			=> _transform.localPosition = component.Value;
	}
}