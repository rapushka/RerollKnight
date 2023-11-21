namespace Code
{
	public class WaitAndThenToState<TNextState> : GameplayStateBase<WaitAndThenToState<TNextState>.StateFeature>
		where TNextState : GameplayStateBase
	{
		public WaitAndThenToState(StateFeature systems) : base(systems) { }

		public sealed class StateFeature : InjectableFeature
		{
			public StateFeature(SystemsFactory factory)
				: base($"{nameof(WaitAndThenToState<TNextState>)}.{nameof(StateFeature)}", factory)
			{
				// Initialize
				Add<WaitingSystem, float>(1f); // TODO: pass duration from externally

				Add<ToStateWhenAllReady<TNextState>>();
			}
		}
	}
}