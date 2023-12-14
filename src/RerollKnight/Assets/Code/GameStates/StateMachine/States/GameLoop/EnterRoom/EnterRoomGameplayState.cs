using Zenject;

namespace Code
{
	public class EnterRoomGameplayState : GameplayStateBase<EnterRoomGameplayState.StateFeature>
	{
		public EnterRoomGameplayState(IInstantiator container) : base(container) { }

		public sealed class StateFeature : StateFeatureBase
		{
			public StateFeature(SystemsFactory factory)
				: base($"{nameof(EnterRoomGameplayState)}.{nameof(StateFeature)}", factory)
			{
				// Initialize
				Add<SwitchCurrentRoomSystem>();
				Add<ClearCurrentPlayerSystem>();
				Add<PutPlayerFirstSystem>();
				// Add<AvailablePickDoorsIfThereIsNoEnemiesSystem>();

				Add<ToState<TurnEndedGameplayState>>();
			}
		}
	}
}