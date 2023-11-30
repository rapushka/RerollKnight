using Code.Component;
using Entitas;
using Entitas.Generic;
using static Entitas.Generic.ScopeMatcher<Code.GameScope>;

namespace Code
{
	public sealed class PickChipSystem : IExecuteSystem
	{
		private readonly IStateChangeBus _stateChangeBus;
		private readonly IGroup<Entity<GameScope>> _chips;

		public PickChipSystem(Contexts contexts, IStateChangeBus stateChangeBus)
		{
			_stateChangeBus = stateChangeBus;

			_chips = contexts.GetGroup(AllOf(Get<Chip>(), Get<AvailableToPick>(), Get<Clicked>()));
		}

		public void Execute()
		{
			foreach (var e in _chips.GetEntities())
			{
				e.Pick();
				e.Is<AvailableToPick>(false);
				_stateChangeBus.ToState<ChipPickedGameplayState>();
			}
		}
	}
}