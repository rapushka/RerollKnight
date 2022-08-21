using Code.Unity.Services.Interfaces;
using Code.Workflow;
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

		private IViewsService ViewService => _contexts.services.viewService.Value;

		public void Initialize()
		{
			const string prefabPath = Constants.ResourcePath.PlayerPrefab;
			GameEntity playerEntity = _contexts.game.playerEntity;

			GameObject playerObject = ViewService.BindViewToEntity(prefabPath, playerEntity);
			playerEntity.AddRigidbody(playerObject.GetComponent<Rigidbody>());
		}
	}
}
