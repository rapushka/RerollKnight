using UnityEngine;

namespace Code.Unity.Views
{
	public class PositionView : MonoBehaviour, IPositionListener
	{
		public void Construct(GameEntity entity)
		{
			entity.AddPositionListener(this);

			if (entity.hasPosition)
			{
				OnPosition(entity, entity.position);
			}
		}
		
		public void OnPosition(GameEntity entity, Vector2 value)
		{
			transform.position = value;
		}
	}
}
