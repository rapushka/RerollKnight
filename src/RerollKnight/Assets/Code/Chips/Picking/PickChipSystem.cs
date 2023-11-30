using System.Collections.Generic;
using System.Linq;
using Code.Component;
using Entitas;
using Entitas.Generic;
using static Entitas.Generic.ScopeMatcher<Code.GameScope>;

namespace Code
{
	public sealed class PickChipSystem : ReactiveSystem<Entity<GameScope>>
	{
		private readonly IStateChangeBus _stateChangeBus;
		private readonly Query _query;

		public PickChipSystem(Contexts contexts, IStateChangeBus stateChangeBus, Query query)
			: base(contexts.Get<GameScope>())
		{
			_stateChangeBus = stateChangeBus;
			_query = query;
		}

		protected override ICollector<Entity<GameScope>> GetTrigger(IContext<Entity<GameScope>> context)
			=> context.CreateCollector(AllOf(Get<Clicked>(), Get<Chip>()));

		protected override bool Filter(Entity<GameScope> entity) => entity.Is<Clicked>();

		protected override void Execute(List<Entity<GameScope>> entities)
		{
			foreach (var e in entities.Where(_query.IsBelongToCurrentActor))
			{
				e.Pick();
				e.Is<Clicked>(false);
				_stateChangeBus.ToState<ChipPickedGameplayState>();
			}
		}
	}
}