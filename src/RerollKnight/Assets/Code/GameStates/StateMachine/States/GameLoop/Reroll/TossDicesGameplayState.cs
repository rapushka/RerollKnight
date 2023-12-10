using Zenject;

namespace Code
{
	public class TossDicesGameplayState : GameplayStateBase<TossDicesGameplayState.StateFeature>
	{
		public TossDicesGameplayState(IInstantiator container) : base(container) { }

		public sealed class StateFeature : StateFeatureBase
		{
			public StateFeature(SystemsFactory factory, IViewConfig viewConfig)
				: base($"{nameof(TossDicesGameplayState)}.{nameof(StateFeature)}", factory)
			{
				// StateMachine.ToState<WaitAndThenToState, WaitAndThenToState.Data>(ToOtherPlayerTurnState);
				Add<WaitingSystem, float>(viewConfig.RerollDuration);
				Add<ToStateWhenAllReady<TurnEndedGameplayState>>();

				Add<MarkAllDicesDetachedSystem>();
				Add<ThrowDicesSystem>();
				Add<RandomRotationSystem>();
			}
		}
	}
}