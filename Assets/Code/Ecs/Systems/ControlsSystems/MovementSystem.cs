using Code.Workflow.Extensions;
using Entitas;

namespace Code.Ecs.Systems.ControlsSystems
{
	public sealed class MovementSystem : IExecuteSystem
	{
		private readonly Contexts _contexts;
		private readonly IGroup<GameEntity> _entities;

		public MovementSystem(Contexts contexts)
		{
			_contexts = contexts;

			_entities = contexts.game.GetGroup
			(
				GameMatcher.AllOf
				(
					GameMatcher.InputReceiver,
					GameMatcher.Rigidbody
				)
			);
		}

		private float VelocityX => MoveDirection * PlayerSpeed;
		private float MoveDirection => _contexts.input.moveDirection.Value;
		private float PlayerSpeed => _contexts.services.balanceService.Value.PlayerSpeed;

		public void Execute()
			=> _entities.GetEntities().ForEach(SetVelocityX);

		private void SetVelocityX(GameEntity e)
			=> e.rigidbody.Value.velocity = e.rigidbody.Value.velocity.SetX(VelocityX);
	}
}
