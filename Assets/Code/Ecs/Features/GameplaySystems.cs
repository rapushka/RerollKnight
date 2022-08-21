using Code.Ecs.Systems.InitializeSystems;

namespace Code.Ecs.Features
{
	public sealed class GameplaySystems : Feature
	{
		public GameplaySystems(Contexts contexts)
			: base(nameof(GameplaySystems))
		{			
		}
	}
}
