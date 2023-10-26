namespace Code
{
	public class WaitingGameState : GameStateBase
	{
		private readonly Contexts _contexts;

		public WaitingGameState(GameStateMachine stateMachine, Contexts contexts) : base(stateMachine)
			=> _contexts = contexts;

		public override void Enter()
		{
			_contexts.game.pickedChipEntity?.Unpick();
			SendRequest.UnpickAll();

			StateMachine.ToState<TurnEndedGameState>();
		}
	}
}