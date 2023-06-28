using System.Collections.Generic;
using Entitas;
using static Code.GameState;
using static GameMatcher;

namespace Code
{
	public sealed class PickCellAsTargetSystem : ReactiveSystem<GameEntity>
	{
		private readonly Contexts _contexts;

		public PickCellAsTargetSystem(Contexts contexts)
			: base(contexts.game)
			=> _contexts = contexts;

		protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
			=> context.CreateCollector(AllOf(Clicked, Cell));

		protected override bool Filter(GameEntity entity) => _contexts.GameStateIs(PickingTarget)
		                                                     && entity.isClicked;

		protected override void Execute(List<GameEntity> entites)
		{
			foreach (var e in entites)
			{
				e.Pick();
				_contexts.ToGameState(WaitingForAbilityUsage);
			}
		}
	}
}