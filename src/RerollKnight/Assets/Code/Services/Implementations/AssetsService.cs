using UnityEngine;

namespace Code
{
	public interface IAssetsService
	{
		T Instantiate<T>(T original) where T : Object;
		T Instantiate<T>(T original, Vector3 position) where T : Object;

		T SpawnBehaviour<T>(T original) where T : EntityBehaviourBase;
		T SpawnBehaviour<T>(T original, Vector3 position) where T : EntityBehaviourBase;
	}

	public class AssetsService : IAssetsService
	{
		public T Instantiate<T>(T original) where T : Object => Object.Instantiate(original);

		public T Instantiate<T>(T original, Vector3 position) where T : Object
			=> Object.Instantiate(original, position, Quaternion.identity);

		public T SpawnBehaviour<T>(T original)
			where T : EntityBehaviourBase
		{
			var behaviour = Instantiate(original);
			behaviour.Register();
			return behaviour;
		}

		public T SpawnBehaviour<T>(T original, Vector3 position)
			where T : EntityBehaviourBase
		{
			var behaviour = Instantiate(original, position);
			behaviour.Register();
			return behaviour;
		}
	}
}