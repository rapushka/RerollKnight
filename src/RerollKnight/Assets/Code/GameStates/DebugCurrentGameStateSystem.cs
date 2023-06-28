using System.Collections.Generic;
using Entitas;

namespace Code
{
	public sealed class DebugCurrentGameStateSystem : ReactiveSystem<GameEntity>
	{
		public DebugCurrentGameStateSystem(Contexts contexts) : base(contexts.game) { }

		protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
			=> context.CreateCollector(GameMatcher.GameState);

		protected override bool Filter(GameEntity entity) => true;

		protected override void Execute(List<GameEntity> entites)
		{
			foreach (var e in entites)
			{
				e.ReplaceDebugName("Game State: " + e.gameState.Value); 
			}
		}
	}
}