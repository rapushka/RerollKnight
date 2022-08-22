using System.Collections.Generic;
using Code.Unity.Services.Interfaces;
using Entitas;
using UnityEngine;

namespace Code.Ecs.Systems.ControlsSystems.Jumping
{
	public sealed class JumpSystem : ReactiveSystem<GameEntity>
	{
		private readonly Contexts _contexts;

		public JumpSystem(Contexts contexts)
			: base(contexts.game)
		{
			_contexts = contexts;
		}

		private IBalanceService BalanceService => _contexts.services.balanceService.Value;

		protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
			=> context.CreateCollector(GameMatcher.Jump);

		protected override bool Filter(GameEntity entity) => entity.hasRigidbody;

		protected override void Execute(List<GameEntity> entites)
		{
			foreach (GameEntity e in entites)
			{
				float jumpForce = BalanceService.Player.JumpForce;
				e.rigidbody.Value.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
			}
		}
	}
}