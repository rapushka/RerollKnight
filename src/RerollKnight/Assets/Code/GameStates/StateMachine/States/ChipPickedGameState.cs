namespace Code
{
	public class ChipPickedGameState : GameStateBase<ChipPickedGameState.StateFeature>
	{
		public ChipPickedGameState(StateFeature systems) : base(systems) { }

		public sealed class StateFeature : InjectableFeature
		{
			public StateFeature(SystemsFactory factory)
				: base($"{nameof(ChipPickedGameState)}.{nameof(StateFeature)}", factory)
			{
				Add<MarkAllTargetsAvailableSystem>();
				Add<AvailabilityFeature>();

				Add<UnpickChipSystem>();
				Add<RepickChipSystem>();

				Add<TargetPickingFeature>();
			}
		}
	}
}