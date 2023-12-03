using System.Linq;
using Code.Component;
using Entitas;
using Entitas.Generic;
using GameMatcher = Entitas.Generic.ScopeMatcher<Code.GameScope>;
using static Entitas.Generic.ScopeMatcher<Code.ChipsScope>;

namespace Code
{
	public sealed class CastAbilitiesSystem : IInitializeSystem
	{
		private readonly IGroup<Entity<ChipsScope>> _abilities;
		private readonly IStateChangeBus _stateChangeBus;

		public CastAbilitiesSystem(Contexts contexts, IStateChangeBus stateChangeBus)
		{
			_stateChangeBus = stateChangeBus;
			_abilities = contexts.GetGroup(AllOf(Get<Component.AbilityState>(), Get<MaxCountOfTargets>()));
		}

		public void Initialize()
		{
			if (_abilities.WhereStateIs(AbilityState.Prepared).Any())
				_stateChangeBus.ToState<CastingAbilitiesGameplayState>();
		}
	}
}