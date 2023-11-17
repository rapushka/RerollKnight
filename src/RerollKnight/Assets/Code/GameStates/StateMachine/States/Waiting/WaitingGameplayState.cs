namespace Code
{
	public class WaitingGameplayState : GameplayStateBase<WaitingGameplayState.StateFeature>
	{
		public WaitingGameplayState(StateFeature systems) : base(systems) { }

		public sealed class StateFeature : InjectableFeature
		{
			public StateFeature(SystemsFactory factory)
				: base($"{nameof(WaitingGameplayState)}.{nameof(StateFeature)}", factory)
			{
				// Initialize
				Add<MarkAllAbilitiesCastingSystem>();
				Add<AbilitiesFeature>();

				// Update
				Add<EndTurnSystem>();

				// Tear down
				Add<ResetAbilityStateSystem>();
			}
		}
	}
}