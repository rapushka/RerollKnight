using System.Collections.Generic;
using Entitas;
using static GameMatcher;

namespace Code
{
	public sealed class SpawnPlayerSystem : ReactiveSystem<GameEntity>
	{
		public SpawnPlayerSystem(Contexts contexts) : base(contexts.game) { }

		private static IMatcher<GameEntity> Coordinates => GameMatcher.Coordinates;

		protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
			=> context.CreateCollector(AllOf(RequireSpawnPlayer, Coordinates));

		protected override bool Filter(GameEntity entity) => true;

		protected override void Execute(List<GameEntity> entites)
		{
			foreach (var e in entites)
			{
				var playerBehaviour = ServicesMediator.SpawnPlayer();
				playerBehaviour.Entity.ReplaceCoordinates(e.coordinates.Value);
			}
		}
	}
}