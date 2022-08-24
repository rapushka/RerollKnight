using Code.Services.Interfaces;
using Code.Workflow.Extensions;
using Entitas;
using UnityEngine;

namespace Code.Ecs.Systems.GameLogicSystems
{
	public sealed class ApplyGravitySystem : IInitializeSystem, IExecuteSystem
	{
		private readonly Contexts _contexts;
		private IGroup<GameEntity> _entities;
		private float _gravityScale;

		public ApplyGravitySystem(Contexts contexts)
		{
			_contexts = contexts;
		}

		private Vector3 ScaledGravity => Physics.gravity * GravityScale * Time.DeltaTime;
		private float GravityScale => _contexts.services.balanceService.Value.GravityScale;
		private ITimeService Time => _contexts.services.timeService.Value;

		public void Initialize()
			=> _entities = _contexts.game.GetAllOf(GameMatcher.CharacterController, GameMatcher.Weighty);

		public void Execute()
			=> _entities.GetEntities().ForEach(ApplyGravity);

		private void ApplyGravity(GameEntity e)
			=> e.characterController.Value.Move(ScaledGravity);
	}
}