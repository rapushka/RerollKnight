using Code.Component;
using Entitas.Generic;
using UnityEngine;

namespace Code
{
	public class DisableColliderOfUnavailableTarget : BaseListener<GameScope, EnableOutline>
	{
		[SerializeField] private Collider _collider;

		public override void OnValueChanged(Entity<GameScope> entity, EnableOutline component)
		{
			_collider.enabled = entity.Is<EnableOutline>(); // TODO: how to hovering?
		}
	}
}