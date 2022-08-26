using UnityEngine;

namespace Code.Services.Interfaces
{
	public interface IBalanceService
	{
		public float GravityScale { get; }
		public float ToDirectionRotationSpeed { get; }
		public IPlayer Player { get; }

		public interface IPlayer
		{
			public float MoveSpeed { get; }
			public float GroundCheckerRadius { get; }
			public float JumpForce { get; }
			Vector3 CrosshairLock { get; }
		}
	}
}