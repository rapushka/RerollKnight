using Code.Component;
using Entitas;
using Entitas.Generic;

namespace Code
{
	public sealed class EnsureActorsInQueueSystem : IInitializeSystem
	{
		private readonly IGroup<Entity<GameScope>> _actors;
		private readonly TurnsQueue _turnsQueue;

		public EnsureActorsInQueueSystem(Contexts contexts, TurnsQueue turnsQueue)
		{
			_turnsQueue = turnsQueue;
			_actors = contexts.GetGroup(ScopeMatcher<GameScope>.Get<Actor>());
		}

		public void Initialize()
		{
			foreach (var actor in _actors)
				_turnsQueue.AddActor(actor);
		}
	}
}