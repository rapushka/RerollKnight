using Code.Component;
using UnityEngine;

namespace Code
{
	[RequireComponent(typeof(Collider))]
	public class HoverReceiver : MonoBehaviour
	{
		[SerializeField] private GameEntityBehaviour _entityBehaviour;

		public bool Hovered
		{
			set
			{
				if (_entityBehaviour.Entity.isEnabled)
					_entityBehaviour.Entity.Is<Hovered>(value);
			}
		}

		private void OnMouseEnter() => Hovered = true;

		private void OnMouseExit() => Hovered = false;
	}
}