using System;
using Code.Services.Interfaces;
using UnityEngine;

namespace Code.Services.Realizations
{
	[Serializable]
	public class SerializableBalanceService : IBalanceService
	{
		[SerializeField] private float _gravityScale;
		[SerializeField] private PlayerRealization _player;

		public float GravityScale => _gravityScale;

		public IBalanceService.IPlayer Player => _player;

		[Serializable]
		public class PlayerRealization : IBalanceService.IPlayer
		{
			[SerializeField] private float _moveSpeed;
			[SerializeField] private float _groundCheckerRadius;
			[SerializeField] private float _jumpForce;

			public float MoveSpeed => _moveSpeed;
			public float GroundCheckerRadius => _groundCheckerRadius;
			public float JumpForce => _jumpForce;
		}
	}
}
