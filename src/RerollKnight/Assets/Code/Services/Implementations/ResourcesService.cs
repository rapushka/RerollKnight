using UnityEngine;

namespace Code
{
	public interface IResourcesService
	{
		EntityBehaviourBase PlayerPrefab { get; }
	}
	
	public class ResourcesService : IResourcesService
	{
		public EntityBehaviourBase PlayerPrefab => Resources.Load<EntityBehaviourBase>("Prefabs/Player");
	}
}