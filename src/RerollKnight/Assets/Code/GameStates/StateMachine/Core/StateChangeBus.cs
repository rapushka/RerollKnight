using System;

namespace Code
{
	public interface IStateChangeBus
	{
		void ToState<TState>() where TState : GameplayStateBase;
	}

	public class StateChangeBus : IStateChangeBus
	{
		public event Action<Type> StateChangeRequired;

		public void ToState<TState>()
			where TState : GameplayStateBase
			=> ToState(typeof(TState));

		public void ToState(Type state)
			=> StateChangeRequired?.Invoke(state);
	}
}