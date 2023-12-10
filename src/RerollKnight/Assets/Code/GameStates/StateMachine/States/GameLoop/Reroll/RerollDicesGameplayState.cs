using Zenject;

namespace Code
{
	public class RerollDicesGameplayState : GameplayStateBase<RerollDicesGameplayState.StateFeature>
	{
		public RerollDicesGameplayState(IInstantiator container) : base(container) { }

		public sealed class StateFeature : StateFeatureBase
		{
			public StateFeature(SystemsFactory factory, IViewConfig viewConfig)
				: base($"{nameof(RerollDicesGameplayState)}.{nameof(StateFeature)}", factory)
			{
				// StateMachine.ToState<WaitAndThenToState, WaitAndThenToState.Data>(ToOtherPlayerTurnState);
				Add<WaitingSystem, float>(viewConfig.RerollDuration);

				Add<MarkAllDicesDetachedSystem>();
				Add<ThrowDicesSystem>();
				Add<RandomRotationSystem>();

				// Add<PassTurnToNextActorSystem>();

				Add<ToCurrentActorStateWhenAllReadySystem>();
				// Add<ToStateWhenAllReady<TurnEndedGameplayState>>();

				// TearDown
				Add<SetRandomSideRolledSystem>();
				Add<UnMarkAllDicesDetachedSystem>();
			}
		}
	}
}