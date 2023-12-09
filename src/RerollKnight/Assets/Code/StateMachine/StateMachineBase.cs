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

		public void ToState<TState, TData>(TData data)
			where TState : IState, IDataReceiver<TData>
		{
			ChangeState(typeof(TState));
			((IDataReceiver<TData>)_currentState)!.Value = data;
			_currentState!.Enter(this);
		}

		public void ToState(Type type)
		{
			ChangeState(type);
			_currentState!.Enter(this);
		}

		public void Execute() => (_currentState as IUpdatableState)?.Execute();

		public void Cleanup() => (_currentState as IUpdatableState)?.Cleanup();

		private void ChangeState(Type type)
		{
			(_currentState as IExitableState)?.Exit();
			_currentState = _dictionary[type];
		}

		protected void AddState<TState>(TState state)
			where TState : IState
			=> _dictionary.Add(state);
	}
}