namespace Code
{
	public class TurnEndedGameplayState : GameplayStateBase<TurnEndedGameplayState.StateFeature>
	{
		public TurnEndedGameplayState(StateFeature systems) : base(systems) { }

		public sealed class StateFeature : InjectableFeature
		{
			public StateFeature(SystemsFactory factory)
				: base($"{nameof(TurnEndedGameplayState)}.{nameof(StateFeature)}", factory)
			{
				// Initialize
				Add<PassTurnToNextPlayerSystem>();
			}
		}
	}
}