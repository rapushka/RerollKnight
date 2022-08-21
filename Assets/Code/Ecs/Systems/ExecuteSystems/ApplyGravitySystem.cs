using Code.Unity.Services.Interfaces;
using Code.Workflow.Extensions;
using Entitas;
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
			_time = _contexts.services.timeService.Value;

			_entities = _contexts.game.GetGroup
			(
				GameMatcher.AllOf(GameMatcher.Rigidbody, GameMatcher.Weighty)
			);
		}

		public void Execute()
		{
			float gravityScale = _contexts.services.balanceService.Value.GravityScale;
			Vector3 scaledGravity = Physics.gravity * gravityScale * _time.DeltaTime;

			_entities.GetEntities()
			         .ForEach((e) => e.rigidbody.Value.velocity += scaledGravity);
		}
	}
}
