namespace Code
{
	public class ObservingGameState : GameStateBase<ObservingGameState.StateFeature>
	{
		public ObservingGameState(StateFeature systems) : base(systems) { }

		// public override void Enter()
		// {
		// 	_entitiesManipulator.UnpickAll(immediately: true);
		// 	RequestEmitter.Instance.Send<MarkAllTargetsUnavailableRequest>();
		// }

		public sealed class StateFeature : InjectableFeature
		{
			public StateFeature(SystemsFactory factory)
				: base(nameof(StateFeature), factory)
			{
				// 
			}
		}
	}
}