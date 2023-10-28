using System.Collections.Generic;
using Entitas;
using static GameMatcher;

namespace Code
{
	public sealed class UnpickChipSystem : ReactiveSystem<GameEntity>
	{
		private readonly GameStateMachine _gameStateMachine;

		public UnpickChipSystem(Contexts contexts, GameStateMachine gameStateMachine)
			: base(contexts.game)
			=> _gameStateMachine = gameStateMachine;

		protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
			=> context.CreateCollector(AllOf(Clicked, PickedChip));

		protected override bool Filter(GameEntity entity) => entity.isClicked;

		protected override void Execute(List<GameEntity> entites)
		{
			foreach (var e in entites)
			{
				_gameStateMachine.ToState<ObservingGameState>();
				e.isClicked = false;
			}
		}
	}
}