using UnityEngine;

namespace Code.Unity.Services.Interfaces
{
	public interface IResourcesService : IService
	{
		GameObject LoadResourceBy(string path);
		
		GameObject PlayerPrefab { get; }
		Transform PlayerSpawnPoint { get; }
	}
}
