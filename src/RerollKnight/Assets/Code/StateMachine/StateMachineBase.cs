using System;
using System.Linq;
using JetBrains.Annotations;

namespace Code
{
	public abstract class StateMachineBase<TStateBase>
		where TStateBase : IState
	{
		private readonly TypeDictionary<TStateBase> _dictionary;

		[CanBeNull] private TStateBase _currentState;

		protected StateMachineBase()
		{
			// ReSharper disable once VirtualMemberCallInConstructor - it's the idea!
			_dictionary = States;
			CurrentState = _dictionary.First().Value;
		}

		public TStateBase CurrentState
		{
			get => _currentState ?? throw new NullReferenceException();
			set
			{
				(_currentState as IExitableState)?.Exit();

				_currentState = value;
				_currentState?.Enter();
			}
		}

		/// <summary> The first state will be entered after initialization </summary>
		protected abstract TypeDictionary<TStateBase> States { get; }

		public void ToState<TState>()
			where TState : TStateBase
			=> CurrentState = _dictionary.Get<TState>();
	}
}