using System.Collections.Generic;
using Code.Services.Interfaces;
using Entitas;

namespace Code.Ecs.Systems.Controls.Jumping
{
	public sealed class JumpSystem : ReactiveSystem<GameEntity>
	{
		private readonly Contexts _contexts;

		public JumpSystem(Contexts contexts)
			: base(contexts.game)
		{
			_contexts = contexts;
		}

		private float JumpForce => BalanceService.Player.JumpForce;
		private IBalanceService BalanceService => _contexts.services.balanceService.Value;

		protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
			=> context.CreateCollector(GameMatcher.Jump);

		protected override bool Filter(GameEntity entity) => entity.hasVelocity;

		protected override void Execute(List<GameEntity> entites)
			=> entites.ForEach(PerformJump);

		private void PerformJump(GameEntity e) 
			=> e.velocity.Value.y = JumpForce;
	}
}