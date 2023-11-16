using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using GameEntity = Entitas.Generic.Entity<Code.GameScope>;

namespace Code
{
	public class TurnsQueue
	{
		private readonly List<GameEntity> _allActors = new();
		private readonly Queue<GameEntity> _queue = new();

		public GameEntity Next()
		{
			if (!_queue.Any())
				RefillQueue();

			return _queue.Dequeue();
		}

		public void OnActorAdded(GameEntity entity)
		{
			_allActors.Add(entity);
			_queue.Enqueue(entity);
		}

		public void OnActorRemoved(GameEntity entity)
		{
			_allActors.Remove(entity);
			RemoveFromQueue(entity);
		}

		private void RefillQueue()
		{
			Debug.Log($"_allActors.Count = {_allActors.Count}");
			_queue.EnqueueRange(_allActors);
		}

		private void RemoveFromQueue(GameEntity actor)
		{
			if (_queue.Contains(actor))
			{
				var temp = _queue.Where((e) => _allActors.Contains(e));
				_queue.Clear();
				_queue.EnqueueRange(temp);
			}
		}
	}
}