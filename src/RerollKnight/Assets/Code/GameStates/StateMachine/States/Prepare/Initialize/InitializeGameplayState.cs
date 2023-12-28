using Zenject;

namespace Code
{
	public class InitializeGameplayState : GameplayStateBase<InitializeGameplayState.StateFeature>
	{
		public InitializeGameplayState(IInstantiator container) : base(container) { }

		public sealed class StateFeature : StateFeatureBase
		{
			public StateFeature(SystemsFactory factory)
				: base($"{nameof(InitializeGameplayState)}.{nameof(StateFeature)}", factory)
			{
				// Add<AddAbilityStateSystem>();
				// Add<StoreChipPositionSystem>();
				// Add<IdentifyChipsSystem>();

				Add<PutPlayerFirstSystem>();
				Add<EnterFirstRoomSystem>();

				// Ready
				// Add<ReadyOnAny<Actor>>();

				Add<ToStateWhenAllReady<RerollDicesGameplayState>>();

				// Tear Down
				Add<HideLoadingCurtainSystem>();
			}
		}
	}
}