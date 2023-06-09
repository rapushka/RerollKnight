using UnityEngine;

namespace Code
{
	public class GameEntityBehaviourOld : MonoBehaviour
	{
		[SerializeField] private GameComponentBehaviourBase[] _registrars;

		public virtual void Initialize(Contexts contexts)
		{
			var entity = contexts.game.CreateEntity();

			foreach (var registrar in _registrars)
			{
				registrar.Register(ref entity);
			}
		}
	}
}