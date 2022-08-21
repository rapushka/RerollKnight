using Code.Workflow;
using Entitas;

namespace Code.Ecs.Systems.InitializeSystems
{
	public sealed class AddPlayerViewToLoadSystem : IInitializeSystem
    {
		private readonly Contexts _contexts;

		public AddPlayerViewToLoadSystem(Contexts contexts)
		{
			_contexts = contexts;
		}
		
		public void Initialize()
		{
			GameEntity playerEntity = _contexts.game.playerEntity;
			playerEntity.AddViewToLoad(Constants.ResourcePath.PlayerPrefab);
		}
	}
}
