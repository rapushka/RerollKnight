using Entitas.Generic;
using UnityEngine;

namespace Code
{
	public interface IAssetsService
	{
		T Instantiate<T>(T original) where T : Object;
		T Instantiate<T>(T original, Vector3 position) where T : Object;
		T Instantiate<T>(T original, Transform parent) where T : Object;

		T SpawnBehaviour<T>(T original) where T : EntityBehaviour;
		T SpawnBehaviour<T>(T original, Vector3 position) where T : EntityBehaviour;
		T SpawnBehaviour<T>(T original, Transform parent) where T : EntityBehaviour;
	}

	public class AssetsService : IAssetsService
	{
		public T Instantiate<T>(T original) where T : Object => Object.Instantiate(original);

		public T Instantiate<T>(T original, Vector3 position) where T : Object
			=> Object.Instantiate(original, position, Quaternion.identity);

		public T Instantiate<T>(T original, Transform parent) where T : Object
			=> Object.Instantiate(original, parent);

		public T SpawnBehaviour<T>(T original)
			where T : EntityBehaviour
		{
			var behaviour = Instantiate(original);
			behaviour.Register(Contexts.Instance);
			return behaviour;
		}

		public T SpawnBehaviour<T>(T original, Vector3 position)
			where T : EntityBehaviour
		{
			var behaviour = Instantiate(original, position);
			behaviour.Register(Contexts.Instance);
			return behaviour;
		}

		public T SpawnBehaviour<T>(T original, Transform parent) where T : EntityBehaviour
		{
			var behaviour = Instantiate(original, parent);
			behaviour.Register(Contexts.Instance);
			return behaviour;
		}
	}
}