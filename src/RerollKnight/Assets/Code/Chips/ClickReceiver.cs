using UnityEngine;

namespace Code
{
	public class ClickReceiver : MonoBehaviour
	{
		[SerializeField] private GameEntityBehaviour _entityBehaviour;

		private void OnMouseDown() => _entityBehaviour.Entity.Is<Clicked>(true);
	}
}