using System.Collections.Generic;
using UnityEngine;
using GameEntity = Entitas.Generic.Entity<Code.GameScope>;

namespace Code
{
	public class TurnsQueue
	{
		private readonly List<GameEntity> _allActors = new();
		private readonly List<GameEntity> _queue = new();

		public GameEntity Next()
		{
			if (!_queue.TryDequeue(out var actor))
			{
				RefillQueue();
				actor = _queue.Dequeue();
			}

			return actor;
		}

		public void OnActorAdded(GameEntity entity)
		{
			_allActors.Add(entity);
			_queue.Add(entity);
		}

		public void OnActorRemoved(GameEntity entity)
		{
			_allActors.Remove(entity);
			_queue.Remove(entity);
		}

		public void PutFirst(GameEntity actor)
		{
			var index = _allActors.IndexOf(actor);
			Debug.Assert(index != -1, $"The queue doesn't contain the {actor}");

			_allActors.RemoveAt(index);
			_allActors.Enqueue(actor);

			RefillQueue();
		}

		private void RefillQueue()
		{
			_queue.Clear();
			_queue.AddRange(_allActors);
		}
	}
}