using Entitas.Generic;
using UnityEngine;

namespace Code.Component
{
	public class GetRotationFromTransform : ComponentBehaviourBase<GameScope>
	{
		[SerializeField] private Transform _transform;

		public override void Add(ref Entity<GameScope> entity)
			=> entity.Add<Rotation, Quaternion>(_transform.rotation);
	}
}