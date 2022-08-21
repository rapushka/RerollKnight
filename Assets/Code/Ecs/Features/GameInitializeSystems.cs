using Code.Ecs.Systems.InitializeSystems;

namespace Code.Ecs.Features
{
	public sealed class GameInitializeSystems : Feature
	{
		public GameInitializeSystems(Contexts contexts)
			: base(nameof(GameInitializeSystems))
		{
			Add(new SpawnPlayerSystem(contexts));
			Add(new BindPlayerViewSystem(contexts));
		}
	}
}
