using Code.Services.Interfaces;
using Entitas;

namespace Code.Ecs.Systems.GameLogic.GameInitialization
{
	public sealed class LoadWeaponsPoolSystem : IInitializeSystem
	{
		private readonly Contexts _contexts;

		public LoadWeaponsPoolSystem(Contexts contexts) => _contexts = contexts;

		private IResourcesService BalanceService => _contexts.services.resourcesService.Value;

		public void Initialize() 
			=> _contexts.game.SetWeaponsPool(BalanceService.Weapons);
	}
}