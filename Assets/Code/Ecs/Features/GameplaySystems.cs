using Code.Ecs.Systems.GameLogicSystems;

namespace Code.Ecs.Features
{
	public sealed class GameplaySystems : Feature
	{
		public GameplaySystems(Contexts contexts)
			: base(nameof(GameplaySystems))
		{
			Add(new ControlsSystems(contexts));
			
			Add(new ApplyGravitySystem(contexts));
			Add(new LookAtSystem(contexts));
		}
	}
}
