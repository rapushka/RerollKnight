using UnityEngine;

namespace Code
{
	public class CoordinatesView : BaseView, ICoordinatesListener
	{
		[SerializeField] private Transform _transform;

		public void OnCoordinates(GameEntity entity, Coordinates value)
			=> _transform.position = value.ToTopDown() + Constants.CoordinatesOnFieldOffset;

		protected override void AddListener(GameEntity entity) => entity.AddCoordinatesListener(this);

		protected override bool HasComponent(GameEntity entity) => entity.hasCoordinates;

		protected override void UpdateValue(GameEntity entity) => OnCoordinates(entity, entity.coordinates.Value);
	}
}