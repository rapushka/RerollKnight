using Entitas;
using UnityEngine;

namespace Code.Ecs.Systems.InitializeSystems
{
	public sealed class SpawnPlayerSystem : IInitializeSystem
	{
		private readonly Contexts _contexts;

		public SpawnPlayerSystem(Contexts contexts)
		{
			_contexts = contexts;
		}

		private Vector2 SpawnPosition
			=> _contexts.game.resourcesService.Value.PlayerSpawnPoint.position;

		public void Initialize()
		{
			GameEntity entity = _contexts.game.CreateEntity();
			entity.AddPosition(SpawnPosition);
		}
	}
}
