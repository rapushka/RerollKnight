using System.Collections.Generic;
using Entitas;
using static GameMatcher;

namespace Code
{
	public sealed class UnpickChipSystem : ReactiveSystem<GameEntity>
	{
		public UnpickChipSystem(Contexts contexts) : base(contexts.game) { }

		protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
			=> context.CreateCollector(AllOf(Clicked, PickedChip));

		protected override bool Filter(GameEntity entity) => entity.isClicked;

		protected override void Execute(List<GameEntity> entites)
		{
			foreach (var e in entites)
			{
				ServicesMediator.GameStateMachine.ToState<ObservingGameState>();
				e.isClicked = false;
			}
		}
	}
}