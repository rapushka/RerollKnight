using System;
using Code.Unity.Services.Interfaces;
using UnityEngine;

namespace Code.Unity.Services.Realizations
{
	[Serializable]
	public class SerializableBalanceService : IBalanceService
	{
		[SerializeField] private float _gravityScale;
		[SerializeField] private float _playerSpeed;
		
		public float GravityScale => _gravityScale;
		public float PlayerSpeed => _playerSpeed;
	}
}
