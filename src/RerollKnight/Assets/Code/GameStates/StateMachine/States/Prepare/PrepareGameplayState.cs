using Entitas.Generic;

namespace Code
{
	public class PrepareGameplayState : GameplayStateBase<PrepareGameplayState.StateFeature>
	{
		public PrepareGameplayState(StateFeature systems) : base(systems) { }

		public sealed class StateFeature : InjectableFeature
		{
			public StateFeature(SystemsFactory factory)
				: base($"{nameof(WaitingGameplayState)}.{nameof(StateFeature)}", factory)
			{
				// Registrations
				Add<RegisterBehavioursSystem>();

				// Initialization
				Add<SpawnFieldSystem>();
				Add<SpawnPlayerSystem>();
				Add<SpawnEnemySystem>();

				Add<AddAbilityStateSystem>();
				Add<StoreChipPositionSystem>();
				Add<IdentifyChipsSystem>();

				Add<ReadyOnAnyActorSystem>();

				// TODO: is it the best state?
				Add<ToStateWhenAllReady<TurnEndedGameplayState>>();
			}
		}
	}
}