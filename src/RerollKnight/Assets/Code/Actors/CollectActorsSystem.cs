using Code.Component;
using Entitas;
using Entitas.Generic;
using static Entitas.Generic.ScopeMatcher<Code.GameScope>;

namespace Code
{
	public sealed class CollectActorsSystem : IExecuteSystem
	{
		private readonly TurnsQueue _turnsQueue;
		private readonly IGroup<Entity<GameScope>> _actors;

		public CollectActorsSystem(Contexts contexts, TurnsQueue turnsQueue)
		{
			_turnsQueue = turnsQueue;
			_actors = contexts.GetGroup(Get<Actor>());
		}

		public void Execute()
		{
			foreach (var e in _actors)
			{
				if (!e.Is<Disabled>() && !_turnsQueue.Contains(e))
					_turnsQueue.AddActor(e);
			}
		}
	}
}