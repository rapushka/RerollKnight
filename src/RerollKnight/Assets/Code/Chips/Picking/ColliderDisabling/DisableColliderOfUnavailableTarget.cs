using Code.Component;
using Entitas.Generic;
using UnityEngine;

namespace Code
{
	public class DisableColliderOfUnavailableTarget : BaseListener<GameScope, AvailableToPick>
	{
		[SerializeField] private Collider _collider;

		public override void OnValueChanged(Entity<GameScope> entity, AvailableToPick component)
		{
			_collider.enabled = entity.Is<AvailableToPick>(); // TODO: how to hovering?
		}
	}
}