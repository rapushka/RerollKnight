using Zenject;

namespace Code
{
	public class WaitAndThenToState<TNextState> : GameplayStateBase<WaitAndThenToState<TNextState>.StateFeature>
		where TNextState : GameplayStateBase
	{
		public WaitAndThenToState(IInstantiator container) : base(container) { }

		public sealed class StateFeature : StateFeatureBase
		{
			public StateFeature(SystemsFactory factory)
				: base($"{nameof(WaitAndThenToState<TNextState>)}.{nameof(StateFeature)}", factory)
			{
				// Initialize
				Add<WaitingSystem, float>(0.5f);

				Add<ToStateWhenAllReady<TNextState>>();
			}
		}
	}
}