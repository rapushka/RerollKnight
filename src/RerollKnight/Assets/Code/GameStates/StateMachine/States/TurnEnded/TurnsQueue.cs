using System.Collections.Generic;
using System.Linq;
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

		public void OnPlayerAdd(GameEntity entity)
		{
			_allActors.Add(entity);
			_queue.Enqueue(entity);
		}

		public void OnPlayerRemove(GameEntity entity)
		{
			_allActors.Remove(entity);
			RemoveFromQueue(entity);
		}

		private void RefillQueue()
		{
			_queue.EnqueueRange(_allActors);
		}

		private void RemoveFromQueue(GameEntity entity)
		{
			if (_queue.Contains(entity))
			{
				var temp = _queue.Where((e) => _allActors.Contains(e));
				_queue.Clear();
				_queue.EnqueueRange(temp);
			}
		}
	}
}