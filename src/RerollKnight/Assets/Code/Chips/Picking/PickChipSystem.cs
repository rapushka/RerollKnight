using System.Collections.Generic;
using Entitas;
using static GameMatcher;

namespace Code
{
	public sealed class PickChipSystem : ReactiveSystem<GameEntity>
	{
		private GameStateMachine _gameStateMachine;

		public PickChipSystem(Contexts contexts, GameStateMachine gameStateMachine)
			: base(contexts.game)
			=> _gameStateMachine = gameStateMachine;

		protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
			=> context.CreateCollector(AllOf(Clicked, Chip));

		protected override bool Filter(GameEntity entity) => entity.isClicked;

		protected override void Execute(List<GameEntity> entities)
		{
			foreach (var e in entities)
			{
				_gameStateMachine.ToState<ChipPickedGameState>();
				e.Pick();
			}
		}
	}
}