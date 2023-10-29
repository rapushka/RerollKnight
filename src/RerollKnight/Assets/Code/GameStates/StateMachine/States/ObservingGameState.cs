namespace Code
{
	public class ObservingGameState : GameStateBase
	{
		private readonly IEntitiesManipulatorService _entitiesManipulator;

		public ObservingGameState(GameStateMachine stateMachine, IEntitiesManipulatorService entitiesManipulator)
			: base(stateMachine)
			=> _entitiesManipulator = entitiesManipulator;

		public override void Enter()
		{
			_entitiesManipulator.UnpickAll(immediately: true);
			RequestHandler.Instance.Send<MarkAllTargetsUnavailableRequest>();
		}
	}
}