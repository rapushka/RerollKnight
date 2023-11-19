using System;
using JetBrains.Annotations;

namespace Code
{
	public abstract class StateMachineBase<TStateBase>
		where TStateBase : IState
	{
		private readonly TypeDictionary<TStateBase> _dictionary = new();

		[CanBeNull] private TStateBase _currentState;

		public TStateBase CurrentState => _currentState ?? throw new NullReferenceException();

		public void ToState<TState>()
			where TState : TStateBase
		{
			ToState(typeof(TState));
		}

		protected void ToState(Type type)
		{
			(_currentState as IExitableState)?.Exit();

			_currentState = _dictionary[type];
			_currentState!.Enter();
		}

		public void Execute() => (_currentState as IUpdatableState)?.Execute();

		public void Cleanup() => (_currentState as IUpdatableState)?.Cleanup();

		protected void AddState<TState>(TState state)
			where TState : TStateBase
			=> _dictionary.Add(state);
	}
}