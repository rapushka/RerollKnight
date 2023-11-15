namespace Code
{
	public class ObservingGameState : GameStateBase<ObservingGameState.StateFeature>
	{
		public ObservingGameState(StateFeature systems) : base(systems) { }

		public sealed class StateFeature : InjectableFeature
		{
			public StateFeature(SystemsFactory factory)
				: base($"{nameof(ObservingGameState)}.{nameof(StateFeature)}", factory)
			{
				// Initialize
				Add<UnpickAllSystem>();
				Add<MarkAllTargetsUnavailableSystem>();

				// Update
				Add<PickChipSystem>();
				Add<UnpickAllOnRequestSystem>();
			}
		}
	}
}