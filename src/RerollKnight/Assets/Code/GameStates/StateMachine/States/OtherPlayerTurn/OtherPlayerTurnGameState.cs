namespace Code
{
	public class OtherPlayerTurnGameState : GameStateBase<OtherPlayerTurnGameState.StateFeature>
	{
		public OtherPlayerTurnGameState(StateFeature systems) : base(systems) { }

		public sealed class StateFeature : InjectableFeature
		{
			public StateFeature(SystemsFactory factory)
				: base($"{nameof(OtherPlayerTurnGameState)}.{nameof(StateFeature)}", factory)
			{
				// Initialize
			}
		}
	}
}