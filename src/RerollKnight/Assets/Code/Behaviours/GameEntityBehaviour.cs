using UnityEngine;

namespace Code
{
	public class GameEntityBehaviour : MonoBehaviour
	{
		[SerializeField] private GameAuthoringBase[] _registrars;

		private void OnEnable() => _registrars = GetComponents<GameAuthoringBase>();

		public void Initialize(Contexts contexts)
		{
			var entity = contexts.game.CreateEntity();

			foreach (var registrar in _registrars)
			{
				registrar.Register(ref entity);
			}
		}
	}
}