using Entitas;

namespace Code
{
	public sealed class ToGameplayStateSystem<TState> : IInitializeSystem
		where TState : GameplayStateBase
	{
		private readonly IStateChangeBus _stateChangeBus;

		public ToGameplayStateSystem(IStateChangeBus stateChangeBus) => _stateChangeBus = stateChangeBus;

		public void Initialize() => _stateChangeBus.ToState<TState>();
	}
}