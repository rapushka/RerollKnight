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
		private readonly Contexts _contexts;

		public PickChipSystem(Contexts contexts, IStateChangeBus stateChangeBus)
			: base(contexts.Get<GameScope>())
		{
			_contexts = contexts;

			_stateChangeBus = stateChangeBus;
		}

		private Entity<GameScope> CurrentActor => _contexts.Get<GameScope>().Unique.GetEntity<CurrentActor>();

		protected override ICollector<Entity<GameScope>> GetTrigger(IContext<Entity<GameScope>> context)
			=> context.CreateCollector(AllOf(Get<Clicked>(), Get<Chip>()));

		protected override bool Filter(Entity<GameScope> entity) => entity.Is<Clicked>();

		protected override void Execute(List<Entity<GameScope>> entities)
		{
			foreach (var e in entities.Where(BelongToCurrentActor))
			{
				e.Pick();
				e.Is<Clicked>(false);
				_stateChangeBus.ToState<ChipPickedGameplayState>();
			}
		}

		private bool BelongToCurrentActor(Entity<GameScope> chip)
			=> chip.Get<BelongToActor>().Value == CurrentActor.Get<ID>().Value;
	}
}