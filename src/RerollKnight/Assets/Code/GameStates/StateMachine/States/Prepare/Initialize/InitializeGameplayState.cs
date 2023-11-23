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
				// Add<AddAbilityStateSystem>();
				// Add<StoreChipPositionSystem>();
				// Add<IdentifyChipsSystem>();

				Add<PutPlayerFirstSystem>();

				// Ready
				// Add<ReadyOnAny<Actor>>();

				// TODO: is it the best state?
				Add<ToStateWhenAllReady<TurnEndedGameplayState>>();
			}
		}
	}
}