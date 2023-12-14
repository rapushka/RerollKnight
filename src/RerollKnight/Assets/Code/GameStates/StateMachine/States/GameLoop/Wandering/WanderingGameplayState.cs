using Zenject;

namespace Code
{
	public class WanderingGameplayState : GameplayStateBase<WanderingGameplayState.StateFeature>
	{
		public WanderingGameplayState(IInstantiator container) : base(container) { }

		public sealed class StateFeature : StateFeatureBase
		{
			public StateFeature(SystemsFactory factory)
				: base($"{nameof(WanderingGameplayState)}.{nameof(StateFeature)}", factory)
			{
				// Initialize
				Add<UnpickAllSystem>();
				Add<MarkAllTargetsUnavailableSystem>();
				Add<HideAllChipsSystem>();
				Add<SpawnDoorsSystem>();

				Add<OnDoorClickSystem>();

				// TearDown
				Add<DestroyDoorsSystem>();
			}
		}
	}
}