using UnityEngine;

namespace Code
{
	public interface IAssetsService
	{
		T Instantiate<T>(T prefab) where T : Object;

		T SpawnBehaviour<T>(T prefab) where T : EntityBehaviourBase;
	}

	public class AssetsService : IAssetsService
	{
		public T Instantiate<T>(T prefab) where T : Object => Object.Instantiate(prefab);

		public T SpawnBehaviour<T>(T prefab)
			where T : EntityBehaviourBase
		{
			var behaviour = Instantiate(prefab);
			behaviour.Register();
			return behaviour;
		}
	}
}