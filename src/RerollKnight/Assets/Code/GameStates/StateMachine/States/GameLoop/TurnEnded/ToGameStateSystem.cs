using Entitas;

namespace Code
{
	public sealed class ToState<TState> : IInitializeSystem
		where TState : GameplayStateBase
	{
		private readonly IStateChangeBus _stateChangeBus;

		public ToState(IStateChangeBus stateChangeBus) => _stateChangeBus = stateChangeBus;

		public void Initialize() => _stateChangeBus.ToState<TState>();
	}
}