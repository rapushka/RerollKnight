using System;

namespace Code
{
	public interface IStateChangeBus
	{
		void ToState<TState>() where TState : GameStateBase;
	}

	public class StateChangeBus : IStateChangeBus
	{
		public event Action<Type> StateChangeRequired;

		public void ToState<TState>()
			where TState : GameStateBase
			=> StateChangeRequired?.Invoke(typeof(TState));
	}
}