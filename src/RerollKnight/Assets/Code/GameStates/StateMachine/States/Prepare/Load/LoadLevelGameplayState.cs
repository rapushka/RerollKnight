using Code.Component;
using Entitas.Generic;
using Zenject;

namespace Code
{
	public class LoadLevelGameplayState : GameplayStateBase<LoadLevelGameplayState.StateFeature>
	{
		public LoadLevelGameplayState(IInstantiator container) : base(container) { }

		public sealed class StateFeature : InjectableFeature
		{
			public StateFeature(SystemsFactory factory)
				: base($"{nameof(LoadLevelGameplayState)}.{nameof(StateFeature)}", factory)
			{
				// Registrations
				Add<RegisterBehavioursSystem>();

				Add<SpawnActorOnRequestSystem>();

				// Initialization
				Add<SpawnPlayerChipsSystem>();
				Add<SpawnFieldSystem>();

				// Ready
				Add<ReadyOnAny<Actor>>();
				// Add<ReadyOnTurnsQueueAny>();

				Add<ToStateWhenAllReady<InitializeGameplayState>>();
			}
		}
	}
}