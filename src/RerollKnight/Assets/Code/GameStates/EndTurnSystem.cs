using Entitas;
using Entitas.Generic;
using static Entitas.Generic.ScopeMatcher<Code.ChipsScope>;

namespace Code
{
	public sealed class EndTurnSystem : ICleanupSystem, IStateTransferSystem
	{
		private readonly IGroup<Entity<ChipsScope>> _abilities;

		public EndTurnSystem(Contexts contexts)
		{
			_abilities = contexts.GetGroup(Get<Component.AbilityState>());
		}

		public StateMachineBase StateMachine { get; set; }

		public void Cleanup()
		{
			if (_abilities.All((e) => e.Get<Component.AbilityState>().Value is not AbilityState.Casting))
				StateMachine.ToState<TurnEndedGameplayState>();
		}
	}
}