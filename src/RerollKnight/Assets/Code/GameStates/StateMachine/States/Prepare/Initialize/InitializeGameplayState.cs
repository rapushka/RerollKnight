using Zenject;

namespace Code
{
	public class InitializeGameplayState : GameplayStateBase<InitializeGameplayState.StateFeature>
	{
		public InitializeGameplayState(IInstantiator container) : base(container) { }

		public sealed class StateFeature : InjectableFeature
		{
			public StateFeature(SystemsFactory factory)
				: base($"{nameof(InitializeGameplayState)}.{nameof(StateFeature)}", factory)
			{
				// Add<AddAbilityStateSystem>();
				// Add<StoreChipPositionSystem>();
				// Add<IdentifyChipsSystem>();

				Add<PutPlayerFirstSystem>();

				// Ready
				// Add<ReadyOnAny<Actor>>();

				Add<ToStateWhenAllReady<TurnEndedGameplayState>>();
			}
		}
	}
}