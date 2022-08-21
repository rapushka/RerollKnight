using Entitas;
using UnityEngine;

namespace Code.Ecs.Systems.InitializeSystems
{
	public sealed class BindPlayerViewSystem : IInitializeSystem
	{
		private readonly Contexts _contexts;

		public BindPlayerViewSystem(Contexts contexts)
		{
			_contexts = contexts;
		}

		public void Initialize()
		{
			GameObject playerPrefab = _contexts.game.resourcesService.Value.PlayerPrefab;
			GameEntity playerEntity = _contexts.game.playerEntity;

			_contexts.game.viewService.Value.BindViewToEntity(playerPrefab, playerEntity);
		}
	}
}
