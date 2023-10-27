namespace Code
{
	public class ObservingGameState : GameStateBase
	{
		public ObservingGameState(GameStateMachine stateMachine) : base(stateMachine) { }

		public override void Enter()
		{
			ServicesMediator.EntitiesManipulator.UnpickAll(immediately: true);
		}
	}
}