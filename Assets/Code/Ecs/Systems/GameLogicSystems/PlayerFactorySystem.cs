using Entitas;
using UnityEngine;

namespace Code.Ecs.Systems.GameLogicSystems
{
	public sealed class PlayerFactorySystem : IInitializeSystem
	{
		private readonly Contexts _contexts;

		public PlayerFactorySystem(Contexts contexts)
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
			player.isInputReceiver = true;
			
			player.AddPosition(SpawnPosition);
			player.AddVelocity(Vector3.zero);
		}
	}
}
