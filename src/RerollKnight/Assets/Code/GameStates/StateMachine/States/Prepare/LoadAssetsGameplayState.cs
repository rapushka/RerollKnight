using Code.Component;
using Entitas.Generic;

namespace Code
{
	public class LoadAssetsGameplayState : GameplayStateBase<LoadAssetsGameplayState.StateFeature>
	{
		public LoadAssetsGameplayState(StateFeature systems) : base(systems) { }

		public sealed class StateFeature : InjectableFeature
		{
			public StateFeature(SystemsFactory factory)
				: base($"{nameof(WaitingGameplayState)}.{nameof(StateFeature)}", factory)
			{
				// Registrations
				Add<RegisterBehavioursSystem>();

				// Initialization
				Add<SpawnFieldSystem>();

				// Ready
				Add<ReadyOnAny<Actor>>();
				// Add<ReadyOnTurnsQueueAny>();

				Add<ToStateWhenAllReady<InitializeGameplayState>>();
			}
		}
	}
}