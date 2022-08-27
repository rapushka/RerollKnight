using System;
using Code.Services.Interfaces;
using UnityEngine;
using static Code.Workflow.Constants;

namespace Code.Services.Realizations
{
	[Serializable]
	public class SerializableResourcesService : IResourcesService
	{
		[SerializeField] private GameObject _playerPrefab;
		[SerializeField] private Transform _playerSpawnPoint;
		[SerializeField] private GameObject _weaponPrefab;

		public GameObject LoadResourceBy(string path)
			=> path switch
			{
				ResourcePath.Player      => PlayerPrefab,
				ResourcePath.DebugWeapon => DebugWeaponPrefab,
				_                        => Exception(),
			};

		private static GameObject Exception()
			=> throw new ArgumentException("Unknown resource path");

		public GameObject PlayerPrefab => _playerPrefab;
		public GameObject DebugWeaponPrefab => _weaponPrefab;
		public Transform PlayerSpawnPoint => _playerSpawnPoint;
	}
}