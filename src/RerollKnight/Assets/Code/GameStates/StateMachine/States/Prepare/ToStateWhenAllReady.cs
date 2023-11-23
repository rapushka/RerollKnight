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
			// 'any' is useless here, just for clarity
			if (!_entities.Any() || _entities.All(IsReady))
				_stateChangeBus.ToState<TState>();
		}

		private bool IsReady(Entity<InfrastructureScope> entity) => entity.Get<Ready>().Value;
	}
}