using Code.Component;

namespace Code
{
	public class InitializeGameplayState : GameplayStateBase<InitializeGameplayState.StateFeature>
	{
		public InitializeGameplayState(StateFeature systems) : base(systems) { }

		public sealed class StateFeature : InjectableFeature
		{
			public StateFeature(SystemsFactory factory)
				: base($"{nameof(InitializeGameplayState)}.{nameof(StateFeature)}", factory)
			{
				Add<AddAbilityStateSystem>();
				Add<StoreChipPositionSystem>();
				Add<IdentifyChipsSystem>();

				// Ready
				Add<ReadyOnAny<Actor>>();
				Add<PutPlayerFirstSystem>();

				// TODO: is it the best state?
				Add<ToStateWhenAllReady<TurnEndedGameplayState>>();
			}
		}
	}
}