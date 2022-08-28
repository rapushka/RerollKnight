using Code.Services.Interfaces;
using Code.Workflow.Extensions;
using Entitas;
using UnityEngine;

namespace Code.Ecs.Systems.Controls.Movement
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
				GameMatcher.Position
			);
		}

		private ITimeService Time => _contexts.services.timeService.Value;
		private Vector3 ScaledDirection => MoveDirection * PlayerSpeed * Time.FixedDeltaTime;
		private Vector3 MoveDirection => _contexts.input.moveDirectionReceive.Value;
		private float PlayerSpeed => _contexts.services.balanceService.Value.Player.MoveSpeed;

		public void Execute() => _entities.ForEach(SetVelocity);

		private void SetVelocity(GameEntity e)
		{
			e.position.Value.x = ScaledDirection.x;
			e.position.Value.z = ScaledDirection.z;
		}
	}
}