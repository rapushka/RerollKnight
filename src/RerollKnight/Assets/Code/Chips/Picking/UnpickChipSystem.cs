using System.Collections.Generic;
using Code.Component;
using Entitas;
using Entitas.Generic;
using static Entitas.Generic.ScopeMatcher<Code.GameScope>;

namespace Code
{
	public sealed class UnpickChipSystem : ReactiveSystem<Entity<GameScope>>
	{
		private readonly IStateChangeBus _stateChangeBus;

		public UnpickChipSystem(Contexts contexts, IStateChangeBus stateChangeBus)
			: base(contexts.Get<GameScope>())
			=> _stateChangeBus = stateChangeBus;

		protected override ICollector<Entity<GameScope>> GetTrigger(IContext<Entity<GameScope>> context)
			=> context.CreateCollector(AllOf(Get<Clicked>(), Get<PickedChip>()));

		protected override bool Filter(Entity<GameScope> entity) => entity.Is<Clicked>();

		protected override void Execute(List<Entity<GameScope>> entites)
		{
			foreach (var e in entites)
			{
				_stateChangeBus.ToState<ObservingGameState>();
				e.Is<Clicked>(false);
			}
		}
	}
}