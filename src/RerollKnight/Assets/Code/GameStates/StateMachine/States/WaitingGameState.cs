namespace Code
{
	public class WaitingGameState : GameStateBase<WaitingGameState.StateFeature>
	{
		public WaitingGameState(StateFeature systems) : base(systems) { }

		public sealed class StateFeature : InjectableFeature
		{
			public StateFeature(SystemsFactory factory)
				: base($"{nameof(WaitingGameState)}.{nameof(StateFeature)}", factory)
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