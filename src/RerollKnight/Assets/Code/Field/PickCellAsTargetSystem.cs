using System.Collections.Generic;
using Entitas;
using static GameMatcher;

namespace Code
{
	public sealed class PickCellAsTargetSystem : ReactiveSystem<GameEntity>
	{
		private readonly GameStateMachine _gameStateMachine;

		public PickCellAsTargetSystem(Contexts contexts, GameStateMachine gameStateMachine)
			: base(contexts.game)
			=> _gameStateMachine = gameStateMachine;

		private GameStateBase CurrentGameState => _gameStateMachine.CurrentState;

		protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
			=> context.CreateCollector(AllOf(Clicked, Cell, AvailableToPick));

		protected override bool Filter(GameEntity entity) => CurrentGameState is ChipPickedGameState
		                                                     && entity.isClicked
		                                                     && entity.isAvailableToPick;

		protected override void Execute(List<GameEntity> entites)
		{
			foreach (var e in entites)
				e.Pick();
		}
	}
}