using Code.Ecs.Systems.InitializeSystems;

namespace Code.Ecs.Features
{
	public sealed class GameInitializationSystems : Feature
	{
		public GameInitializationSystems(Contexts contexts)
			: base(nameof(GameInitializationSystems))
		{
			Add(new SpawnPlayerSystem(contexts));
			Add(new BindPlayerViewSystem(contexts));
		}
	}
}
