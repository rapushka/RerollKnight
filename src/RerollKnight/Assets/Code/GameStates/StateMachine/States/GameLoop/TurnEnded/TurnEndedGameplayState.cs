using Zenject;

namespace Code
{
	public class TurnEndedGameplayState : GameplayStateBase<TurnEndedGameplayState.StateFeature>
	{
		public TurnEndedGameplayState(IInstantiator container) : base(container) { }

		public sealed class StateFeature : StateFeatureBase
		{
			public StateFeature(SystemsFactory factory)
				: base($"{nameof(TurnEndedGameplayState)}.{nameof(StateFeature)}", factory)
			{
				// Initialize
				Add<UnpickAllSystem>();
				Add<MarkAllTargetsUnavailableSystem>();

				// Add<StartRerollSystem>();
				// Add<PassTurnToNextActorSystem>();
				// Add<ToCurrentActorStateIfNotRerollSystem>();
				Add<RerollIfNeededSystem>();

				// Tear Down
				// Add<MarkAvailableChipsSystem>();
			}
		}
	}
}