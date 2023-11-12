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
				Add<MarkAllAbilitiesCastingSystem>();

				Add<AbilitiesFeature>();
			}
		}
	}
}