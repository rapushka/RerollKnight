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

				// Initialization
				Add<SpawnActorsSystem>();
				// Add<SpawnActorOnRequestSystem>();
				// Add<SpawnPlayerChipsSystem>();
				Add<SpawnFieldSystem>();

				// Ready
				// Add<ReadyOnAny<Actor>>();
				// Add<ReadyOnTurnsQueueAny>();

				Add<ToState<InitializeGameplayState>>();
			}
		}
	}
}