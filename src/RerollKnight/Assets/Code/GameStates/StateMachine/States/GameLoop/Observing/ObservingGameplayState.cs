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
				Add<UnpickAllSystem>();
				Add<MarkAllTargetsUnavailableSystem>();

				// Execute
				Add<PickChipSystem>();
			}
		}
	}
}