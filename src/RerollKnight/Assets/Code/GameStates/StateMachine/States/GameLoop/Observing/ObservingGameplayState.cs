namespace Code
{
	public class ObservingGameplayState : GameplayStateBase<ObservingGameplayState.StateFeature>
	{
		public ObservingGameplayState(StateFeature systems) : base(systems) { }

		public sealed class StateFeature : InjectableFeature
		{
			public StateFeature(SystemsFactory factory)
				: base($"{nameof(ObservingGameplayState)}.{nameof(StateFeature)}", factory)
			{
				// Initialize
				Add<UnpickAllSystem>();
				Add<MarkAllTargetsUnavailableSystem>();

				// Update
				Add<PickChipSystem>();
			}
		}
	}
}