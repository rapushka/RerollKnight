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
			(_currentState as IExitableState)?.Exit();

			_currentState = _dictionary.Get<TState>();
			_currentState!.Enter();
		}

		public void OnUpdate()
		{
			(_currentState as IUpdatableState)?.OnUpdate();
		}

		protected void AddState<TState>(TState state)
			where TState : TStateBase
			=> _dictionary.Add(state);
	}
}