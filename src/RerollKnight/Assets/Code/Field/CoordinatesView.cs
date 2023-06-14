using UnityEngine;

namespace Code
{
	public class CoordinatesView : MonoBehaviour, ICoordinatesListener
	{
		[SerializeField] private Transform _transform;

		public void Register(GameEntity entity)
		{
			entity.AddCoordinatesListener(this);

			if (entity.hasCoordinates)
			{
				OnCoordinates(entity, entity.coordinates.Value);
			}
		}

		public void OnCoordinates(GameEntity entity, Coordinates value)
			=> _transform.position = value.ToTopDown();
	}
}