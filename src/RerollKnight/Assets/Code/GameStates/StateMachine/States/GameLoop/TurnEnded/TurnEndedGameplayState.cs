using Zenject;

namespace Code
{
	public class TurnEndedGameplayState : GameplayStateBase<TurnEndedGameplayState.StateFeature>
	{
		public TurnEndedGameplayState(IInstantiator container) : base(container) { }

		public sealed class StateFeature : InjectableFeature
		{
			public StateFeature(SystemsFactory factory)
				: base($"{nameof(TurnEndedGameplayState)}.{nameof(StateFeature)}", factory)
			{
				// Initialize
				Add<UnpickAllSystem>();
				Add<MarkAllTargetsUnavailableSystem>();

				Add<PassTurnToNextActorSystem>();
				Add<ToStateForCurrentActorSystem>();

				// Tear Down
				Add<MarkChipsAvailableSystem>();
			}
		}
	}
}