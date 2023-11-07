using System.Collections.Generic;
using Entitas;
using Entitas.Generic;

namespace Code
{
	public class WaitingGameState : GameStateBase
	{
		private readonly IGroup<Entity<ChipsScope>> _abilities;

		public WaitingGameState(GameStateMachine stateMachine) : base(stateMachine)
			=> _abilities = Contexts.Instance.GetGroup(ScopeMatcher<ChipsScope>.Get<State>());

		private IEnumerable<Entity<ChipsScope>> PreparedAbilities => _abilities.WhereStateIs(AbilityState.Prepared);

		public override void Enter()
		{
			foreach (var ability in PreparedAbilities)
				ability.Replace<State, AbilityState>(AbilityState.Casting);
		}
	}
}