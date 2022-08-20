using System;
using Code.Unity.Services.Interfaces;
using UnityEngine;

namespace Code.Unity.Services.Realizations
{
	[Serializable] public class SerializableResourcesService : IResourcesService
	{
		[SerializeField] private GameObject _playerPrefab;
		[SerializeField] private Transform _playerSpawnPoint;

		public GameObject PlayerPrefab => _playerPrefab;
		public Transform PlayerSpawnPoint => _playerSpawnPoint;
	}
}
