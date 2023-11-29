using Code.Component;
using Entitas;
using Entitas.Generic;
using static Entitas.Generic.ScopeMatcher<Code.GameScope>;

namespace Code
{
	public class PickRandomOurChip : IInitializeSystem
	{
		private readonly Contexts _contexts;
		private readonly IGroup<Entity<GameScope>> _chips;

		public PickRandomOurChip(Contexts contexts)
		{
			_contexts = contexts;

			_chips = contexts.GetGroup(Get<Chip>());
		}

		private Entity<GameScope> CurrentActor => _contexts.Get<GameScope>().Unique.GetEntity<CurrentActor>();

		public void Initialize()
			=> _chips.Where(BelongToCurrentActor).PickRandom().Pick();

		private bool BelongToCurrentActor(Entity<GameScope> chip)
			=> chip.Get<BelongToActor>().Value == CurrentActor.Get<ID>().Value;
	}
}