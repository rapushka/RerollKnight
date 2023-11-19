using Code.Component;
using Entitas.Generic;

namespace Code
{
	public class InitializeGameplayState : GameplayStateBase<InitializeGameplayState.StateFeature>
	{
		public InitializeGameplayState(StateFeature systems) : base(systems) { }

		public sealed class StateFeature : InjectableFeature
		{
			public StateFeature(SystemsFactory factory)
				: base($"{nameof(WaitingGameplayState)}.{nameof(StateFeature)}", factory)
			{
				// Registrations
				Add<RegisterBehavioursSystem>();

				// Initialization
				Add<SpawnFieldSystem>();

				Add<AddAbilityStateSystem>();
				Add<StoreChipPositionSystem>();
				Add<IdentifyChipsSystem>();

				// Ready
				Add<ReadyOnAny<Actor>>();
				Add<ReadyOnTurnsQueueAny>();

				// TODO: is it the best state?
				Add<ToStateWhenAllReady<TurnEndedGameplayState>>();
			}
		}
	}
}