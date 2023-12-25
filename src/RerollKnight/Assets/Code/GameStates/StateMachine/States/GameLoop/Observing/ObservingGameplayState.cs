using Zenject;

namespace Code
{
	public class ObservingGameplayState : GameplayStateBase<ObservingGameplayState.StateFeature>
	{
		public ObservingGameplayState(IInstantiator container) : base(container) { }

		public sealed class StateFeature : StateFeatureBase
		{
			public StateFeature(SystemsFactory factory)
				: base($"{nameof(ObservingGameplayState)}.{nameof(StateFeature)}", factory)
			{
				// Initialize
				Add<CheckIfRoomCompletedSystem>();
				Add<UnpickAllSystem>();
				Add<MarkAllTargetsUnavailableSystem>();
				Add<AvailablePickDoorsIfThereIsNoEnemiesSystem>();
				Add<MarkTargetsHoverableOnInitializeSystem>();

				// Execute
				Add<PickChipSystem>();

				// Tear Down
				Add<UnMarkTargetsHoverableOnTearDownSystem>();
			}
		}
	}
}