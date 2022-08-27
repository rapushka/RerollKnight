using Code.Ecs.Components;
using Code.Workflow;
using Entitas;

namespace Code.Ecs.Systems.View
{
	public sealed class BindViewsToLoadSystem : IInitializeSystem
    {
		private readonly Contexts _contexts;

		public BindViewsToLoadSystem(Contexts contexts)
		{
			_contexts = contexts;
		}
		
		public void Initialize()
		{
			GameEntity player = _contexts.game.playerEntity;
			
			player.AddViewToLoad(Constants.ResourcePath.Player);
			
			CurrentWeaponComponent weapon = player.currentWeapon;

			// _contexts.services.resourcesService.Value
			//          .DebugWeaponPrefab.
		}
	}
}
