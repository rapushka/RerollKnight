using Code.Component;
using Entitas;
using Entitas.Generic;
using static Entitas.Generic.ScopeMatcher<Code.GameScope>;

namespace Code
{
	public sealed class PickChipSystem : IExecuteSystem, IStateTransferSystem
	{
		private readonly IGroup<Entity<GameScope>> _chips;

		public PickChipSystem(Contexts contexts)
		{
			_chips = contexts.GetGroup(AllOf(Get<Chip>(), Get<AvailableToPick>(), Get<Clicked>()));
		}

		public StateMachineBase StateMachine { get; set; }

		public void Execute()
		{
			foreach (var e in _chips.GetEntities())
			{
				e.Pick();
				StateMachine.ToState<ChipPickedGameplayState>();
			}
		}
	}
}