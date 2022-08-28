using Code.Services.Interfaces;
using Code.Workflow.Extensions;
using Entitas;
using UnityEngine;

namespace Code.Ecs.Systems.View
{
	public sealed class TurnByDirectionSystem : IExecuteSystem
	{
		private readonly Contexts _contexts;
		private readonly IGroup<GameEntity> _entities;

		public TurnByDirectionSystem(Contexts contexts)
		{
			_contexts = contexts;
			_entities = contexts.game.GetAllOf
			(
				GameMatcher.CharacterController,
				GameMatcher.TargetRotation
			);	
		}
		
		private float ScaledRotationSpeed => RotationSpeed * Time.FixedDeltaTime;
		private float RotationSpeed => _contexts.services.balanceService.Value.ToDirectionRotationSpeed;
		private ITimeService Time => _contexts.services.timeService.Value;

		public void Execute() => _entities.ForEach(Turn);

		private void Turn(GameEntity entity) => Rotate(entity, entity.transform);

		private void Rotate(GameEntity entity, Transform transform)
		{
			transform.rotation = Quaternion.RotateTowards
			(
				transform.rotation,
				entity.targetRotation,
				ScaledRotationSpeed
			);
		}
	}
}