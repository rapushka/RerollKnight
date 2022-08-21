using Code.Ecs.Systems.ModelSystems;

namespace Code.Ecs.Features
{
	public sealed class GameplaySystems : Feature
	{
		public GameplaySystems(Contexts contexts)
			: base(nameof(GameplaySystems))
		{
			Add(new ControlsSystems(contexts));
			
			Add(new ApplyGravitySystem(contexts));
		}
	}
}
