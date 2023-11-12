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
				Add<UnpickAllSystem>();
				Add<MarkAllTargetsUnavailableSystem>();

				// Add<UnpickChipSystem>();
				// Add<RepickChipSystem>();
				Add<PickChipSystem>();

				Add<UnpickAllOnRequestSystem>();
				Add<UnpickAllAbilitiesSystem>();
			}
		}
	}
}