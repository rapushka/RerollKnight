using UnityEngine;

namespace Code
{
	public class ClickReceiver : MonoBehaviour
	{
		[SerializeField] private GameEntityBehaviour _entityBehaviour;

		private void OnMouseDown()
		{
			var entity = _entityBehaviour.Entity;

			entity.isClicked = true;
		}
	}
}