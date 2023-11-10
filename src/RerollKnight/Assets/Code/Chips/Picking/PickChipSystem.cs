using System.Collections.Generic;
using Code.Component;
using Entitas;
using Entitas.Generic;
using static Entitas.Generic.ScopeMatcher<Code.GameScope>;

namespace Code
{
	public sealed class PickChipSystem : ReactiveSystem<Entity<GameScope>>
	{
		private readonly GameStateMachine _gameStateMachine;

		public PickChipSystem(Contexts contexts, GameStateMachine gameStateMachine)
			: base(contexts.Get<GameScope>())
			=> _gameStateMachine = gameStateMachine;

		protected override ICollector<Entity<GameScope>> GetTrigger(IContext<Entity<GameScope>> context)
			=> context.CreateCollector(AllOf(Get<Clicked>(), Get<Chip>()));

		protected override bool Filter(Entity<GameScope> entity) => entity.Is<Clicked>();

		protected override void Execute(List<Entity<GameScope>> entities)
		{
			foreach (var e in entities)
			{
				_gameStateMachine.ToState<ChipPickedGameState>();
				e.Pick();
			}
		}
	}
}