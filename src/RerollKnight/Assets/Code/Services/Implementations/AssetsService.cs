using UnityEngine;

namespace Code
{
	public interface IAssetsService
	{
		T Instantiate<T>(T prefab) where T : Object;
	}

	public class AssetsService : IAssetsService
	{
		public T Instantiate<T>(T prefab) where T : Object => Object.Instantiate(prefab);
	}
}