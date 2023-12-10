using Zenject;

namespace Code
{
	public class PassTurnGameplayState : GameplayStateBase<PassTurnGameplayState.StateFeature>
	{
		public PassTurnGameplayState(IInstantiator container) : base(container) { }

		public sealed class StateFeature : StateFeatureBase
		{
			public StateFeature(SystemsFactory factory)
				: base($"{nameof(RerollDicesGameplayState)}.{nameof(StateFeature)}", factory)
			{
				// Initialize
				Add<PassTurnToNextActorSystem>();
				Add<ToCurrentActorStateSystem>();

				// TearDown
				Add<MarkAvailableChipsSystem>();
			}
		}
	}
}