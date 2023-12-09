using Code.Component;
using Entitas;
using Entitas.Generic;

namespace Code
{
	public sealed class ToStateWhenAllReady<TState> : ICleanupSystem, IStateTransferSystem
		where TState : GameplayStateBase
	{
		private readonly IGroup<Entity<InfrastructureScope>> _entities;

		public ToStateWhenAllReady(Contexts contexts)
		{
			_entities = contexts.GetGroup(ScopeMatcher<InfrastructureScope>.Get<Ready>());
		}

		public StateMachineBase StateMachine { get; set; }

		public void Cleanup()
		{
			// 'any' is useless here, just for clarity
			if (!_entities.Any() || _entities.All(IsReady))
				StateMachine.ToState<TState>();
		}

		private bool IsReady(Entity<InfrastructureScope> entity) => entity.Get<Ready>().Value;
	}
}