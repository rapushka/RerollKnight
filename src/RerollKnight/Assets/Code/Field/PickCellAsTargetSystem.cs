using System.Collections.Generic;
using Entitas;
using static GameMatcher;

namespace Code
{
	public sealed class PickCellAsTargetSystem : ReactiveSystem<GameEntity>
	{
		public PickCellAsTargetSystem(Contexts contexts)
			: base(contexts.game) { }

		private static GameStateBase CurrentGameState => ServicesMediator.GameStateMachine.CurrentState;

		protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
			=> context.CreateCollector(AllOf(Clicked, Cell));

		protected override bool Filter(GameEntity entity) => CurrentGameState is ChipPickedGameState
		                                                     && entity.isClicked;

		protected override void Execute(List<GameEntity> entites)
		{
			foreach (var e in entites)
			{
				e.Pick();
			}
		}
	}
}