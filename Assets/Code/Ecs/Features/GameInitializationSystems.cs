using Code.Ecs.Systems.GameLogicSystems;

namespace Code.Ecs.Features
{
	public sealed class GameInitializationSystems : Feature
	{
		public GameInitializationSystems(Contexts contexts)
			: base(nameof(GameInitializationSystems))
		{
			Add(new PlayerFactorySystem(contexts));
		}
	}
}
