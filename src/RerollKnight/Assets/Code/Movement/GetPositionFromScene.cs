using UnityEngine;

namespace Code
{
	public class GetPositionFromScene : GameComponentBehaviourBase
	{
		[SerializeField] private Transform _transform;

		public override void AddToEntity(ref GameEntity entity) => entity.AddPosition(_transform.position);

		public override void RemoveFromEntity(ref GameEntity entity) => entity.RemovePosition();
	}
}