using System.Collections.Generic;
using UnityEngine;

namespace Code.Services.Interfaces
{
	public interface IResourcesService
	{
		GameObject LoadResourceBy(string path);

		GameObject PlayerPrefab { get; }
		GameObject DebugWeaponPrefab { get; }
		IEnumerable<GameObject> Weapons { get; }
		Transform PlayerSpawnPoint { get; }
	}
}