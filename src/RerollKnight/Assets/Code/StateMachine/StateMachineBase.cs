using System;
using System.Linq;
using JetBrains.Annotations;

namespace Code
{
	public abstract class StateMachineBase
	{
		private readonly TypeDictionary<IState> _dictionary;

		[CanBeNull] private IState _currentState;

		protected StateMachineBase()
		{
			// ReSharper disable once VirtualMemberCallInConstructor - it's the idea
			_dictionary = States;
			CurrentState = _dictionary.First().Value;
		}

		public IState CurrentState
		{
			get => _currentState ?? throw new NullReferenceException();
			set
			{
				(_currentState as IExitableState)?.Exit();

				_currentState = value;
				_currentState?.Enter();
			}
		}

		protected abstract TypeDictionary<IState> States { get; }

		public void ToState<TState>()
			where TState : IState
			=> CurrentState = _dictionary.Get<TState>();
	}
}