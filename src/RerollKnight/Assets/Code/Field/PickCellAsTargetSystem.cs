using System.Collections.Generic;
using Entitas;
using Entitas.Generic;
using static Entitas.Generic.ScopeMatcher<Code.GameScope>;

namespace Code
{
	public sealed class PickCellAsTargetSystem : ReactiveSystem<Entity<GameScope>>
	{
		private readonly GameStateMachine _gameStateMachine;

		public PickCellAsTargetSystem(Contexts contexts, GameStateMachine gameStateMachine)
			: base(contexts.Get<GameScope>())
			=> _gameStateMachine = gameStateMachine;

		private GameStateBase CurrentGameState => _gameStateMachine.CurrentState;

		protected override ICollector<Entity<GameScope>> GetTrigger(IContext<Entity<GameScope>> context)
			=> context.CreateCollector(AllOf(Get<Clicked>(), Get<Cell>(), Get<AvailableToPick>()));

		protected override bool Filter(Entity<GameScope> entity) => CurrentGameState is ChipPickedGameState
		                                                            && entity.Is<Clicked>()
		                                                            && entity.Is<AvailableToPick>();

		protected override void Execute(List<Entity<GameScope>> entites)
		{
			foreach (var e in entites)
				e.Pick();
		}
	}
}