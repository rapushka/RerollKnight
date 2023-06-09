using UnityEngine;

namespace Code
{
	public class GameEntityBehaviourOld : MonoBehaviour
	{
		[SerializeField] private GameComponentBehaviourBase[] _componentBehaviours;

		public virtual void Initialize(Contexts contexts)
		{
			var entity = contexts.game.CreateEntity();

			foreach (var component in _componentBehaviours)
			{
				component.AddToEntity(ref entity);
			}
		}
	}
}