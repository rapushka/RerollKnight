using UnityEngine;

namespace Code
{
	public class PositionView : BaseView, IPositionListener
	{
		[SerializeField] private Transform _transform;

		public void OnPosition(GameEntity entity, Vector3 value) => _transform.position = value;

		protected override void AddListener(GameEntity entity) => entity.AddPositionListener(this);

		protected override bool HasComponent(GameEntity entity) => entity.hasPosition;

		protected override void UpdateValue(GameEntity entity) => OnPosition(entity, entity.position.Value);
	}
}