using Code.Services.Interfaces;
using Code.Workflow.Extensions;
using Entitas;
using UnityEngine;

namespace Code.Ecs.Systems.GameLogic
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

		private Vector3 ScaledGravity => DirectedGravity * Time.FixedDeltaTime;
		private Vector3 DirectedGravity => Vector3.down * GravityScale;
		private float GravityScale => _contexts.services.balanceService.Value.GravityScale;
		private ITimeService Time => _contexts.services.timeService.Value;

		public void Initialize()
			=> _entities = _contexts.game.GetAllOf(GameMatcher.Position, GameMatcher.Weighty);

		public void Execute() => _entities.ForEach(ApplyGravity);

		private void ApplyGravity(GameEntity e)
		{
			if (e.position.Value.y > DirectedGravity.y)
			{
				e.position.Value += ScaledGravity;
			}
			else
			{
				e.position.Value = ScaledGravity;
			}
		}
	}
}