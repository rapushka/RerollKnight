using Code.Component;
using Entitas;
using Entitas.Generic;
using static Entitas.Generic.ScopeMatcher<Code.GameScope>;

namespace Code
{
	public sealed class EndTurnOnOutOfChipsSystem : IExecuteSystem, IStateTransferSystem
	{
		private readonly IGroup<Entity<GameScope>> _availableChips;

		public EndTurnOnOutOfChipsSystem(Contexts contexts)
		{
			_availableChips = contexts.GetGroup(AllOf(Get<Chip>(), Get<AvailableToPick>()));
		}

		public StateMachineBase StateMachine { get; set; }

		public void Execute()
		{
			if (!_availableChips.Any())
				StateMachine.ToState<TurnEndedGameplayState>();
		}
	}
}