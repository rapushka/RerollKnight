using System;

namespace Code
{
	public interface IStateChangeBus
	{
		void ToState<TState>();
	}

	public class StateChangeBus : IStateChangeBus
	{
		public event Action<Type> StateChangeRequired;

		public void ToState<TState>() => StateChangeRequired?.Invoke(typeof(TState));
	}
}