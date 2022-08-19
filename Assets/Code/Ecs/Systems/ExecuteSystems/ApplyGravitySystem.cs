using Code.Unity.Services.Interfaces;
using Entitas;
using UnityEngine;

namespace Code.Ecs.Systems.ExecuteSystems
{
	public sealed class ApplyGravitySystem : IExecuteSystem
	{
		private readonly ITimeService _time;
		private readonly IGroup<GameEntity> _entities;
		private readonly float _gravityScale;

		public ApplyGravitySystem(Contexts contexts)
		{
			_time = contexts.game.timeService.Value;

			_entities = contexts.game.GetGroup
			(
				GameMatcher.AllOf(GameMatcher.Weighty, GameMatcher.Position)
			);
			_gravityScale = contexts.game.gravityScaleEntity.gravityScale;
		}

		public void Execute()
		{
			Vector2 gravity = new(0, _gravityScale);
			gravity.y *= _time.DeltaTime;

			foreach (GameEntity e in _entities)
			{
				e.position.Value += gravity;
			}
		}
	}
}
