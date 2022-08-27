using UnityEngine;

namespace Code.Services.Interfaces
{
	public interface IResourcesService
	{
		GameObject LoadResourceBy(string path);
		
		GameObject PlayerPrefab { get; }
		GameObject DebugWeaponPrefab { get; }
		Transform PlayerSpawnPoint { get; }
	}
}
