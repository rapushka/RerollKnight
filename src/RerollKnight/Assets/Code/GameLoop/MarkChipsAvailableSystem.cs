using Code.Component;
using Entitas;
using Entitas.Generic;
using static Entitas.Generic.ScopeMatcher<Code.GameScope>;

namespace Code
{
	public sealed class MarkChipsAvailableSystem : ITearDownSystem
	{
		private readonly Query _query;
		private readonly IGroup<Entity<GameScope>> _chips;

		public MarkChipsAvailableSystem(Contexts contexts, Query query)
		{
			_query = query;

			_chips = contexts.GetGroup(Get<Chip>());
		}

		public void TearDown()
		{
			foreach (var chip in _chips)
				chip.Is<AvailableToPick>(_query.IsBelongToCurrentActor(chip));
		}
	}
}