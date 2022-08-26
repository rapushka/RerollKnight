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
				GameMatcher.CharacterController
			);
		}

		private Vector3 ReceivedDirection => _contexts.input.moveDirectionReceive.Value;
		private float ScaledRotationSpeed => RotationSpeed * Time.DeltaTime;
		private float RotationSpeed => _contexts.services.balanceService.Value.ToDirectionRotationSpeed;
		private ITimeService Time => _contexts.services.timeService.Value;

		public void Execute() => _entities.ForEach(Turn);

		private void Turn(GameEntity e)
		{
			if (ReceivedDirection == Vector3.zero) 
			{
				return;
			}

			Quaternion targetRotation = Quaternion.LookRotation(ReceivedDirection, Vector3.up);
			
			GetTransform(e).rotation = Quaternion.RotateTowards
			(
				GetTransform(e).rotation,
				targetRotation,
				ScaledRotationSpeed
			);
		}
		
		private static Transform GetTransform(GameEntity e) 
			=> e.characterController.Value.transform;
	}
}