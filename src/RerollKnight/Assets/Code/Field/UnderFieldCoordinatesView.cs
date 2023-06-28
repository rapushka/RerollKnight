using UnityEngine;

namespace Code
{
	public class UnderFieldCoordinatesView : BaseView, ICoordinatesUnderFieldListener
	{
		[SerializeField] private Transform _transform;

		public void OnCoordinatesUnderField(GameEntity entity, Coordinates value)
			=> _transform.position = value.ToTopDown();

		protected override void AddListener(GameEntity entity) => entity.AddCoordinatesUnderFieldListener(this);

		protected override bool HasComponent(GameEntity entity) => entity.hasCoordinatesUnderField;

		protected override void UpdateValue(GameEntity entity)
			=> OnCoordinatesUnderField(entity, entity.coordinatesUnderField.Value);
	}
}