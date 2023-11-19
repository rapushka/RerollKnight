using Code.Component;
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
				Add<SpawnActorOnRequestSystem>();

				Add<AddAbilityStateSystem>();
				Add<StoreChipPositionSystem>();
				Add<IdentifyChipsSystem>();

				// Ready
				Add<ReadyOnAny<Actor>>();

				// TODO: is it the best state?
				Add<ToStateWhenAllReady<TurnEndedGameplayState>>();
			}
		}
	}
}