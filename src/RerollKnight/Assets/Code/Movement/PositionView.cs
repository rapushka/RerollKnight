using Entitas.Generic;
using UnityEngine;

namespace Code
{
	public class PositionView : BaseListener<GameScope, Position>
	{
		[SerializeField] private Transform _transform;

		public override void OnValueChanged(Entity<GameScope> entity, Position component)
			=> _transform.position = component.Value;
	}
}