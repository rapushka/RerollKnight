using System;
using System.Collections.Generic;
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
		[Space]
		[SerializeField] private GameObject _weaponPrefab;
		[SerializeField] private List<GameObject> _weapons;

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
		public IEnumerable<GameObject> Weapons => _weapons;
		public Transform PlayerSpawnPoint => _playerSpawnPoint;
	}
}