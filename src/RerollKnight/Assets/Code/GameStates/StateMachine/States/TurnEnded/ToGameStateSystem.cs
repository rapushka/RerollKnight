using Entitas;

namespace Code
{
	public sealed class ToGameStateSystem<TState> : IInitializeSystem
		where TState : GameStateBase
	{
		private readonly IStateChangeBus _stateChangeBus;

		public ToGameStateSystem(IStateChangeBus stateChangeBus) => _stateChangeBus = stateChangeBus;

		public void Initialize() => _stateChangeBus.ChangeState<TState>();
	}
}