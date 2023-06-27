using UnityEngine;

namespace Code
{
	public interface IResourcesService
	{
		GameEntityBehaviour PlayerPrefab { get; }
	}
	
	public class ResourcesService : IResourcesService
	{
		public GameEntityBehaviour PlayerPrefab => Resources.Load<GameEntityBehaviour>("Player/Prefab");
	}
}