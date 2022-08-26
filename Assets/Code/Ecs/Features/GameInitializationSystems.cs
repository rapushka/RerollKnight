using Code.Ecs.Systems.GameLogic;

namespace Code.Ecs.Features
{
	public sealed class GameInitializationSystems : Feature
	{
		public GameInitializationSystems(Contexts contexts)
			: base(nameof(GameInitializationSystems))
		{
			Add(new SpawnPlayerSystem(contexts));
		}
	}
}
