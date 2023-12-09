using Zenject;

namespace Code
{
	public class ChipPickedGameplayState : GameplayStateBase<ChipPickedGameplayState.StateFeature>
	{
		public ChipPickedGameplayState(IInstantiator container) : base(container) { }

		public sealed class StateFeature : StateFeatureBase
		{
			public StateFeature(SystemsFactory factory)
				: base($"{nameof(ChipPickedGameplayState)}.{nameof(StateFeature)}", factory)
			{
				// Initialize
				Add<PrepareAbilitiesOfPickedChipSystem>();
				Add<AvailabilityFeature>();

				// Update
				Add<UnpickChipSystem>();
				Add<RepickChipSystem>();

				Add<TargetPickingFeature>();
			}
		}
	}
}