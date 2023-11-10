namespace Code
{
	public class WaitingGameState : GameStateBase<WaitingGameState.StateFeature>
	{
		public WaitingGameState(StateFeature systems) : base(systems) { }

		// _abilities = Contexts.Instance.GetGroup(ScopeMatcher<ChipsScope>.Get<State>());
		// private IEnumerable<Entity<ChipsScope>> PreparedAbilities => _abilities.WhereStateIs(AbilityState.Prepared);

		// public override void Enter()
		// {
		// 	foreach (var ability in PreparedAbilities)
		// 		ability.Replace<State, AbilityState>(AbilityState.Casting);
		// }

		public sealed class StateFeature : InjectableFeature
		{
			public StateFeature(SystemsFactory factory)
				: base($"{nameof(WaitingGameState)}.{nameof(StateFeature)}", factory)
			{
				// 
			}
		}
	}
}