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

				// Generation
				Add<GenerateLevelSystem>();

				// Initialization
				Add<EnsureActorsInQueueSystem>();
				// Add<BindAllToCurrentRoomSystem>();

				Add<ToStateWhenAllReady<InitializeGameplayState>>();
			}
		}
	}
}