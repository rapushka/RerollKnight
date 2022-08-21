using Code.Ecs.Systems.InitializeSystems;
using Code.Ecs.Systems.ReactiveSystems;

namespace Code.Ecs.Features
{
	public sealed class GameInitializationSystems : Feature
	{
		public GameInitializationSystems(Contexts contexts)
			: base(nameof(GameInitializationSystems))
		{
			Add(new SpawnPlayerSystem(contexts));
			Add(new AddPlayerViewToLoadSystem(contexts));
			Add(new LoadViewSystem(contexts));
		}
	}
}
