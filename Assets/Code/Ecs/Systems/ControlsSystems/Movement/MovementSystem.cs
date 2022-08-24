using Code.Services.Interfaces;
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

			_entities = contexts.game.GetAllOf
			(
				GameMatcher.InputReceiver,
				GameMatcher.Velocity
			);
		}

		private ITimeService Time => _contexts.services.timeService.Value;
		private Vector3 ScaledDirection => MoveDirection * PlayerSpeed * Time.DeltaTime;
		private Vector3 MoveDirection => _contexts.input.moveDirectionReceive.Value;
		private float PlayerSpeed => _contexts.services.balanceService.Value.Player.MoveSpeed;

		public void Execute() => _entities.ForEach(SetVelocity);

		private void SetVelocity(GameEntity e)
		{
			e.velocity.Value.x = ScaledDirection.x;
			e.velocity.Value.z = ScaledDirection.z;
		}
	}
}