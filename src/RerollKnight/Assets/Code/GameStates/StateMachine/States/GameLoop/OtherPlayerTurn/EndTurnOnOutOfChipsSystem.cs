using Code.Component;
using Entitas;
using Entitas.Generic;
using static Entitas.Generic.ScopeMatcher<Code.GameScope>;

namespace Code
{
	public sealed class EndTurnOnOutOfChipsSystem : IExecuteSystem
	{
		private readonly IGroup<Entity<GameScope>> _availableChips;
		private readonly StateChangeBus _stateChangeBus;

		public EndTurnOnOutOfChipsSystem(Contexts contexts, StateChangeBus stateChangeBus)
		{
			_availableChips = contexts.GetGroup(AllOf(Get<Chip>(), Get<AvailableToPick>()));
			_stateChangeBus = stateChangeBus;
		}

		public void Execute()
		{
			if (!_availableChips.Any())
				_stateChangeBus.ToState<TurnEndedGameplayState>();
		}
	}
}