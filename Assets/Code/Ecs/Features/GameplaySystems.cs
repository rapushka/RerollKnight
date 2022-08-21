using Code.Ecs.Systems.ExecuteSystems;

namespace Code.Ecs.Features
{
	public sealed class GameplaySystems : Feature
	{
		public GameplaySystems(Contexts contexts)
			: base(nameof(GameplaySystems))
		{
			Add(new ApplyGravitySystem(contexts));
		}
	}
}
