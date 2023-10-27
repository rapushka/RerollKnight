namespace Code
{
	public class TurnEndedGameState : GameStateBase, IExitableState
	{
		public TurnEndedGameState(GameStateMachine stateMachine) : base(stateMachine) { }

		public override void Enter() => StateMachine.ToState<ObservingGameState>();

		public void Exit() => ServicesMediator.EntitiesManipulator.UnpickAll(immediately: true);
	}
}