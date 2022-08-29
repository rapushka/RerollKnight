using UnityEngine;

namespace Code.Unity.Views.Registrars
{
	public class SpawnPositionRegistrar : MonoBehaviour, IViewComponentRegistrar
	{
		[SerializeField] private Vector3 _position;

		public void Register(GameEntity entity)
		{
			entity.AddSpawnPosition(_position);
		}
	}
}