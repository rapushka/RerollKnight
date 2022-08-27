using Entitas;
using static Code.Workflow.Constants;

namespace Code.Ecs.Systems.View
{
	public sealed class BindViewsToLoadSystem : IInitializeSystem
    {
		private readonly Contexts _contexts;

		public BindViewsToLoadSystem(Contexts contexts)
		{
			_contexts = contexts;
		}

		private GameEntity Player => _contexts.game.playerEntity;
		private GameEntity CurrentWeapon => Player.currentWeapon.Value;

		public void Initialize()
		{
			Player.AddViewToLoad(ResourcePath.Player);
			CurrentWeapon.AddViewToLoad(ResourcePath.DebugWeapon);
		}
    }
}
