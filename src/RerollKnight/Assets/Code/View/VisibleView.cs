using Code.Component;
using Entitas.Generic;
using UnityEngine;

namespace Code
{
	public class VisibleView : BaseListener<GameScope, Visible>
	{
		// [SerializeField] private GameObject _target;

		public override void OnValueChanged(Entity<GameScope> entity, Visible component)
		{
			var position = entity.Get<Position>().Value;
			entity.Replace<DestinationPosition, Vector3>(position.Set(y: -10)); // TODO: set from layout service

			// _target.SetActive(entity.Is<Visible>());
		}
	}
}