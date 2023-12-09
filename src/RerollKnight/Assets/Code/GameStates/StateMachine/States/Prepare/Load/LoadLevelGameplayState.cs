using Entitas.Generic;
using Zenject;

namespace Code
{
	public class LoadLevelGameplayState : GameplayStateBase<LoadLevelGameplayState.StateFeature>
	{
		public LoadLevelGameplayState(IInstantiator container) : base(container) { }

		public sealed class StateFeature : StateFeatureBase
		{
			public StateFeature(SystemsFactory factory)
				: base($"{nameof(LoadLevelGameplayState)}.{nameof(StateFeature)}", factory)
			{
				// Registrations
				Add<RegisterBehavioursSystem>();

				// Initialization
				Add<SpawnFieldSystem>();
				Add<SpawnActorsSystem>();
				Add<SpawnWallsSystem>();
				// Add<SpawnActorOnRequestSystem>();
				// Add<SpawnPlayerChipsSystem>();
				Add<EnsureActorsInQueueSystem>();

				// Ready
				// Add<ReadyOnAny<Actor>>();
				// Add<ReadyOnTurnsQueueAny>();

				Add<ToState<InitializeGameplayState>>();
			}
		}
	}
}