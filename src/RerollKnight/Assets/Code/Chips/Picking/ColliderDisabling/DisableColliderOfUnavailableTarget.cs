using Code.Component;
using Entitas.Generic;
using UnityEngine;

namespace Code
{
	public class DisableColliderOfUnavailableTarget
		: BaseListener<GameScope>,
		  IRegistrableListener<GameScope, AvailableToPick>,
		  IRegistrableListener<GameScope, Hoverable>
	{
		[SerializeField] private Collider _collider;

		public override void Register(Entity<GameScope> entity)
		{
			entity.AddListener<AvailableToPick>(this);
			entity.AddListener<Hoverable>(this);

			UpdateValue(entity);
		}

		public void OnValueChanged(Entity<GameScope> entity, Hoverable component) => UpdateValue(entity);

		public void OnValueChanged(Entity<GameScope> entity, AvailableToPick component) => UpdateValue(entity);

		private void UpdateValue(Entity<GameScope> entity)
			=> _collider.enabled = entity.Is<AvailableToPick>() || entity.Is<Hoverable>();
	}
}