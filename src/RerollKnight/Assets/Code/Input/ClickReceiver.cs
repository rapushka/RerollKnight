using Code.Component;
using UnityEngine;

namespace Code
{
	[RequireComponent(typeof(Collider))]
	public class ClickReceiver : MonoBehaviour
	{
		[SerializeField] private GameEntityBehaviour _entityBehaviour;

		private void OnMouseDown() => _entityBehaviour.Entity.Is<Clicked>(true);
	}
}