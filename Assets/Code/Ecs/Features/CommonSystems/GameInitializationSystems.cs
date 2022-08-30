using Code.Ecs.Systems.GameLogic.GameInitialization;

namespace Code.Ecs.Features.CommonSystems
{
	public sealed class GameInitializationSystems : Feature
	{
		public GameInitializationSystems(Contexts contexts)
			: base(nameof(GameInitializationSystems))
		{
			Add(new SpawnPlayerSystem(contexts));
			Add(new LoadWeaponSystem(contexts));
			Add(new LoadWeaponsPoolSystem(contexts));
		}
	}
}
