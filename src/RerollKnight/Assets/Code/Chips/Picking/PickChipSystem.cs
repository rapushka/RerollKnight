using System.Collections.Generic;
using Entitas;
using static GameMatcher;

namespace Code
{
	public sealed class PickChipSystem : ReactiveSystem<GameEntity>
	{
		private readonly Contexts _contexts;

		public PickChipSystem(Contexts contexts)
			: base(contexts.game)
			=> _contexts = contexts;

		protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
			=> context.CreateCollector(AllOf(Clicked, Chip));

		protected override bool Filter(GameEntity entity) => entity.isClicked;

		protected override void Execute(List<GameEntity> entities)
		{
			foreach (var e in entities)
			{
				_contexts.ToGameState(GameState.PickingTarget);
				e.Pick();
			}
		}
	}
}