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

		public GameObject LoadResourceBy(string path)
			=> path switch
			{
				ResourcePath.PlayerPrefab => PlayerPrefab,
				_                         => Exception(),
			};

		private static GameObject Exception()
			=> throw new ArgumentException("Unknown resource path");

		public GameObject PlayerPrefab => _playerPrefab;
		public Transform PlayerSpawnPoint => _playerSpawnPoint;
	}
}
