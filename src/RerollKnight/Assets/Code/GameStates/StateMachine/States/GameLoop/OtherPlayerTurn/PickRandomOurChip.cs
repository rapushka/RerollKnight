using Code.Component;
using Entitas;
using Entitas.Generic;
using static Entitas.Generic.ScopeMatcher<Code.GameScope>;

namespace Code
{
	public class PickRandomOurChip : IInitializeSystem
	{
		private readonly IGroup<Entity<GameScope>> _chips;

		public PickRandomOurChip(Contexts contexts)
		{
			_chips = contexts.GetGroup(AllOf(Get<Chip>(), Get<AvailableToPick>()));
		}

		public void Initialize()
		{
			if (_chips.Any())
			{
				var randomChip = _chips.PickRandom();
				randomChip.Pick();
				randomChip.Is<AvailableToPick>(false);
			}
		}
	}
}