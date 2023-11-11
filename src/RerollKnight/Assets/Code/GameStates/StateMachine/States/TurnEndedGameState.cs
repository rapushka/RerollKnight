namespace Code
{
	public class TurnEndedGameState : GameStateBase<TurnEndedGameState.StateFeature>
	{
		public TurnEndedGameState(StateFeature systems) : base(systems) { }

		// public override void Enter() => StateMachine.ToState<ObservingGameState>();

		// public void Exit() { }

		public sealed class StateFeature : InjectableFeature
		{
			public StateFeature(SystemsFactory factory)
				: base($"{nameof(TurnEndedGameState)}.{nameof(StateFeature)}", factory)
			{
				Add<ToGameStateSystem<ObservingGameState>>();
			}
		}
	}
}