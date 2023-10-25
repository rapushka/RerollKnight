using System;
using System.Linq;
using JetBrains.Annotations;

namespace Code
{
	public abstract class StateMachineBase
		// where TStateBase : IState
	{
		private readonly TypeDictionary<IState> _dictionary;

		[CanBeNull] private IState _currentState;

		public IState CurrentState
		{
			get => _currentState ?? throw new NullReferenceException();
			set
			{
				_currentState = value;
				_currentState?.Enter(this);
			}
		}

		protected StateMachineBase(TypeDictionary<IState> dictionary)
		{
			_dictionary = dictionary;
			SetState(_dictionary.First().Key);
		}

		public void ToState<TState>() where TState : IState
		{
			ExitCurrentState();
			SetState(typeof(TState));
		}

		private void SetState(Type type)
		{
			CurrentState = _dictionary[type];
		}

		private void ExitCurrentState()
		{
			if (_currentState is IExitableState exitableState)
				exitableState.Exit();

			CurrentState = default;
		}
	}
}