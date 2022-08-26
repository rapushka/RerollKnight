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

		private Quaternion TargetRotation => Quaternion.LookRotation(ReceivedDirection, Vector3.up);
		private bool IsMoved => ReceivedDirection != Vector3.zero;
		private Vector3 ReceivedDirection => _contexts.input.moveDirectionReceive.Value;
		private float ScaledRotationSpeed => RotationSpeed * Time.DeltaTime;
		private float RotationSpeed => _contexts.services.balanceService.Value.ToDirectionRotationSpeed;
		private ITimeService Time => _contexts.services.timeService.Value;

		public void Execute() => _entities.ForEach(Turn);

		private void Turn(GameEntity e) 
			=> e.transform.Value.Do(RotateToMoveDirection, @if: IsMoved);

		private void RotateToMoveDirection(Transform t)
		{
			t.rotation = Quaternion.RotateTowards
			(
				t.rotation,
				TargetRotation,
				ScaledRotationSpeed
			);
		}
	}
}