using System;
using Zenject;

namespace Code
{
	public class WaitAndThenToState
		: GameplayStateBase<WaitAndThenToState.StateFeature>, IDataReceiver<WaitAndThenToState.Data>
	{
		public WaitAndThenToState(IInstantiator container) : base(container) { }

		public Data Value { set => Feature.Value = value; }

		public sealed class StateFeature : StateFeatureBase
		{
			private readonly IDataReceiver<float> _waitingSystem;
			private readonly IDataReceiver<Type> _toNextStateSystem;

			public StateFeature(SystemsFactory factory)
				: base($"{nameof(WaitAndThenToState)}.{nameof(StateFeature)}", factory)
			{
				// Initialize
				_waitingSystem = Add<WaitingSystem>();
				_toNextStateSystem = Add<ToStateWhenAllReady>();
			}

			public Data Value
			{
				set
				{
					_waitingSystem.Value = value.WaitingDuration;
					_toNextStateSystem.Value = value.NextState;
				}
			}
		}

		public static Data To<TState>(float after) => new(typeof(TState), after);

		public class Data
		{
			public Type NextState;
			public float WaitingDuration;

			public Data(Type nextState, float waitingDuration)
			{
				NextState = nextState;
				WaitingDuration = waitingDuration;
			}
		}
	}
}