using Code.Component;
using Entitas;
using Entitas.Generic;
using static Entitas.Generic.ScopeMatcher<Code.GameScope>;

namespace Code
{
	public sealed class RemoveDestroyedActorFromQueueSystem : IExecuteSystem
	{
		private readonly IGroup<Entity<GameScope>> _entities;
		private readonly TurnsQueue _turnsQueue;

		public RemoveDestroyedActorFromQueueSystem(Contexts contexts, TurnsQueue turnsQueue)
		{
			_entities = contexts.GetGroup(AllOf(Get<Actor>(), Get<Destroyed>()));
			_turnsQueue = turnsQueue;
		}

		public void Execute()
		{
			foreach (var e in _entities.GetEntities())
				_turnsQueue.RemoveActor(e);
		}
	}
}