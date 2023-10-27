namespace Code
{
	public class GameStateMachine : StateMachineBase<GameStateBase>
	{
		private readonly Contexts _contexts;

		public GameStateMachine(Contexts contexts) => _contexts = contexts;

		protected override TypeDictionary<GameStateBase> States
			=> new()
			{
				new ObservingGameState(this),
				new WaitingGameState(this),
				new ChipPickedGameState(this),
				new TurnEndedGameState(this),
			};
	}
}