namespace Code.Ecs.Features.CommonSystems
{
	public sealed class GameplaySystems : Feature
	{
		public GameplaySystems(Contexts contexts)
			: base(nameof(GameplaySystems))
		{
			Add(new ControlsSystems(contexts));
		}
	}
}
