using System.Linq;
using Code.Component;
using Entitas;
using Entitas.Generic;
using static Entitas.Generic.ScopeMatcher<Code.ChipsScope>;

namespace Code
{
	public sealed class CastAbilitiesSystem : IInitializeSystem, IStateTransferSystem
	{
		private readonly IGroup<Entity<ChipsScope>> _abilities;

		public CastAbilitiesSystem(Contexts contexts)
			=> _abilities = contexts.GetGroup(AllOf(Get<Component.AbilityState>(), Get<MaxCountOfTargets>()));

		public StateMachineBase StateMachine { get; set; }

		public void Initialize()
		{
			if (_abilities.WhereStateIs(AbilityState.Prepared).Any())
				StateMachine.ToState<StartCastAnimationGameplayState>();
		}
	}
}