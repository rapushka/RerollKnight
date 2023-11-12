using System;

namespace Code
{
	public interface IStateChangeBus
	{
		void ChangeState<TState>();
	}

	public class StateChangeBus : IStateChangeBus
	{
		public event Action<Type> StateChangeRequired;

		public void ChangeState<TState>() => StateChangeRequired?.Invoke(typeof(TState));
	}
}