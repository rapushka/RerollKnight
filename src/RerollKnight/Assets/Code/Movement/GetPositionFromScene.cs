using Code.Component;
using Entitas.Generic;
using UnityEngine;

namespace Code
{
	public class GetPositionFromScene : ComponentBehaviourBase<GameScope>
	{
		[SerializeField] private Transform _transform;

		public override void Add(ref Entity<GameScope> entity)
			=> entity.Add<Position, Vector3>(_transform.position);
	}
}