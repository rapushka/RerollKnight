using Entitas;
using Entitas.Generic;
using static Entitas.Generic.ScopeMatcher<Code.ChipsScope>;

namespace Code
{
	public sealed class EndTurnSystem : ICleanupSystem
	{
		private readonly IStateChangeBus _stateChangeBus;
		private readonly IGroup<Entity<ChipsScope>> _abilities;

		public EndTurnSystem(Contexts contexts, IStateChangeBus stateChangeBus)
		{
			_stateChangeBus = stateChangeBus;
			_abilities = contexts.GetGroup(Get<Component.AbilityState>());
		}

		public void Cleanup()
		{
			if (_abilities.All((e) => e.Get<Component.AbilityState>().Value is not AbilityState.Casting))
			{
				_stateChangeBus.ToState<TurnEndedGameState>();
			}
		}
	}
}