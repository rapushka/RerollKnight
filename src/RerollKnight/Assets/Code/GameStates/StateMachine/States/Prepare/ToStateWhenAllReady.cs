using Code.Component;
using Entitas;
using Entitas.Generic;

namespace Code
{
	public sealed class ToStateWhenAllReady<TState> : ICleanupSystem
		where TState : GameplayStateBase
	{
		private readonly IGroup<Entity<InfrastructureScope>> _entities;
		private readonly StateChangeBus _stateChangeBus;

		public ToStateWhenAllReady(Contexts contexts, StateChangeBus stateChangeBus)
		{
			_entities = contexts.GetGroup(ScopeMatcher<InfrastructureScope>.Get<Ready>());
			_stateChangeBus = stateChangeBus;
		}

		public void Cleanup()
		{
			if (_entities.All((e) => e.Get<Ready>().Value))
				_stateChangeBus.ToState<TState>();
		}
	}
}