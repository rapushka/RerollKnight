using Code.Workflow;
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
			=> _contexts.services.resourcesService.Value.PlayerSpawnPoint.position;

		public void Initialize()
		{
			GameEntity player = _contexts.game.CreateEntity();
			player.isPlayer = true;
			player.isWeighty = true;
			player.AddViewToLoad(Constants.ResourcePath.PlayerPrefab);

			player.AddPosition(SpawnPosition);
		}
	}
}
