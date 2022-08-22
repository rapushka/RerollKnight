using Code.Ecs.Systems.ModelSystems;

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
