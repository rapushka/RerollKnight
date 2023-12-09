using System;
using JetBrains.Annotations;

namespace Code
{
	public abstract class StateMachineBase
	{
		private readonly TypeDictionary<IState> _dictionary = new();

		[CanBeNull] private IState _currentState;

		public IState CurrentState => _currentState ?? throw new NullReferenceException();

		public void ToState<TState>()
			where TState : IState
		{
			ToState(typeof(TState));
		}

		protected void ToState(Type type)
		{
			(_currentState as IExitableState)?.Exit();

			_currentState = _dictionary[type];
			_currentState!.Enter(this);
		}

		public void Execute() => (_currentState as IUpdatableState)?.Execute();

		public void Cleanup() => (_currentState as IUpdatableState)?.Cleanup();

		protected void AddState<TState>(TState state)
			where TState : IState
			=> _dictionary.Add(state);
	}
}