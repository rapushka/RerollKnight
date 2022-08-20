using Code.Unity.Services.Interfaces;
using Entitas;
using Unity.VisualScripting;
using UnityEngine;

namespace Code.Ecs.Systems.ExecuteSystems
{
	public sealed class ApplyGravitySystem : IInitializeSystem, IExecuteSystem
	{
		private readonly Contexts _contexts;
		private IGroup<GameEntity> _entities;
		private float _gravityScale;
		private ITimeService _time;

		public ApplyGravitySystem(Contexts contexts)
		{
			_contexts = contexts;
		}

		public void Initialize()
		{
			_time = _contexts.game.timeService.Value;
			
			_entities = _contexts.game.GetGroup
			(
				GameMatcher.AllOf(GameMatcher.Weighty, GameMatcher.Position)
			);
		}

		public void Execute()
		{
			float gravityScale = _contexts.game.balanceService.Value.GravityScale;
			float scaledY = gravityScale * _time.DeltaTime;
			Vector2 gravity = new(0, -scaledY);

			foreach (GameEntity e in _entities)
			{
				e.position.Value += gravity;
			}
		}
	}
}
