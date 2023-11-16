using Code.Component;
using Entitas;
using Entitas.Generic;
using UnityEngine;
using static Entitas.Generic.ScopeMatcher<Code.GameScope>;

namespace Code
{
	public sealed class InitializeActorsSystem : IInitializeSystem
	{
		private readonly TurnsQueue _turnsQueue;
		private readonly IGroup<Entity<GameScope>> _entities;

		public InitializeActorsSystem(Contexts contexts, TurnsQueue turnsQueue)
		{
			_entities = contexts.GetGroup(AnyOf(Get<Player>(), Get<Enemy>()));
			_turnsQueue = turnsQueue;
		}

		public void Initialize()
		{
			foreach (var e in _entities)
			{
				e.Is<Actor>(true);
				_turnsQueue.OnActorAdded(e);

				Debug.Log("actor enqueued");
			}
		}
	}
}