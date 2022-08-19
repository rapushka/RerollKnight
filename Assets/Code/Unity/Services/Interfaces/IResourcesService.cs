using UnityEngine;

namespace Code.Unity.Services.Interfaces
{
	public interface IResourcesService : IService
	{
		GameObject PlayerPrefab { get; }
		Transform PlayerSpawnPoint { get; }
	}
}
