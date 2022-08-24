using Code.Workflow.Extensions;
using Entitas;
using UnityEngine;

namespace Code.Ecs.Systems.ControlsSystems.Movement
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

		private Vector2 Velocity => MoveDirection * PlayerSpeed;
		private Vector2 MoveDirection => _contexts.input.moveDirectionReceive.Value;
		private float PlayerSpeed => _contexts.services.balanceService.Value.Player.MoveSpeed;

		public void Execute()
			=> _entities.GetEntities().ForEach(SetVelocity);

		private void SetVelocity(GameEntity e)
			=> e.rigidbody.Value.velocity = VelocityToTopDown(e);

		private Vector3 VelocityToTopDown(GameEntity e) 
			=> new(Velocity.x, e.rigidbody.Value.velocity.y, Velocity.y);
	}
}
