using Code.Unity.Services.Interfaces;
using Code.Workflow;
using Entitas;

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
			GameEntity playerEntity = _contexts.game.playerEntity;

			ViewService.BindViewToEntity(Constants.ResourcePath.PlayerPrefab, playerEntity);
		}
	}
}
