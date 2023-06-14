using System.Collections.Generic;
using Entitas;
using static GameMatcher;

namespace Code
{
	public sealed class SpawnPlayerSystem : ReactiveSystem<GameEntity>
	{
		private readonly Contexts _contexts;

		public SpawnPlayerSystem(Contexts contexts) : base(contexts.game)
			=> _contexts = contexts;

		private static IMatcher<GameEntity> Coordinates => GameMatcher.Coordinates;

		protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
			=> context.CreateCollector(AllOf(RequireSpawnPlayer, Coordinates));

		protected override bool Filter(GameEntity entity) => true;

		protected override void Execute(List<GameEntity> entites)
		{
			foreach (var e in entites)
			{
				var player = _contexts.game.CreateEntity();
				player.isPlayer = true;
				player.AddCoordinates(e.coordinates.Value);
			}
		}
	}
}