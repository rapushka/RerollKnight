using UnityEngine;

namespace Code
{
	public class FieldCoordinatesView : BaseView, ICoordinatesListener
	{
		[SerializeField] private Transform _transform;

		public void OnCoordinates(GameEntity entity, Coordinates value) => _transform.position = value.ToTopDown();

		protected override void AddListener(GameEntity entity) => entity.AddCoordinatesListener(this);

		protected override bool HasComponent(GameEntity entity) => entity.hasCoordinates;

		protected override void UpdateValue(GameEntity entity) => OnCoordinates(entity, entity.coordinates.Value);
	}
}