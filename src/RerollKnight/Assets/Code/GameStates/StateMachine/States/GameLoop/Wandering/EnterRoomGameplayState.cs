using Zenject;

namespace Code
{
	public class EnterRoomGameplayState : GameplayStateBase<EnterRoomGameplayState.StateFeature>
	{
		public EnterRoomGameplayState(IInstantiator container) : base(container) { }

		public sealed class StateFeature : StateFeatureBase
		{
			public StateFeature(SystemsFactory factory)
				: base($"{nameof(WanderingGameplayState)}.{nameof(StateFeature)}", factory)
			{
				// move player to opposite door
				// exit prev room
				// enter next room

				// To Observing State
			}
		}
	}
}