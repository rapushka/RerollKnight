using System.Collections.Generic;
using UnityEngine;
using GameEntity = Entitas.Generic.Entity<Code.GameScope>;

namespace Code
{
	public class TurnsQueue
	{
		public List<GameEntity> AllActors { get; } = new();
		public List<GameEntity> Queue     { get; } = new();

		public GameEntity Next()
		{
			if (!Queue.TryDequeue(out var actor))
			{
				RefillQueue();
				actor = Queue.Dequeue();
			}

			return actor;
		}

		public bool Contains(GameEntity entity) => AllActors.Contains(entity);

		public void AddActor(GameEntity entity)
		{
			AllActors.Add(entity);
			Queue.Add(entity);
		}

		public void RemoveActor(GameEntity entity)
		{
			AllActors.Remove(entity);
			Queue.Remove(entity);
		}

		public void PutFirst(GameEntity actor)
		{
			var index = AllActors.IndexOf(actor);
			Debug.Assert(index != -1, $"The queue doesn't contain the {actor}");

			AllActors.RemoveAt(index);
			AllActors.Enqueue(actor);

			RefillQueue();
		}

		private void RefillQueue()
		{
			Queue.Clear();
			Queue.AddRange(AllActors);
		}
	}
}