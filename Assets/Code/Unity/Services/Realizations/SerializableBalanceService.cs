using System;
using Code.Unity.Services.Interfaces;
using UnityEngine;

namespace Code.Unity.Services.Realizations
{
	[Serializable]
	public class SerializableBalanceService : IBalanceService
	{
		[SerializeField] private float _gravityScale;
		
		public float GravityScale => _gravityScale;
	}
}
