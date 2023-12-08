using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using GameEntity = Entitas.Generic.Entity<Code.GameScope>;

namespace Code
{
	public class TurnsQueue
	{
		private GameEntity _current;

		public List<GameEntity> Queue { get; } = new();

		public bool CurrentIsFirst => _current == Queue.First();

		public GameEntity Next()
		{
			_current = Queue.ItemAfter(_current);
			return _current;
		}

		public bool Contains(GameEntity entity) => Queue.Contains(entity);

		public void AddActor(GameEntity entity)
		{
			Queue.Add(entity);
			// _current ??= entity;
		}

		public void RemoveActor(GameEntity entity)
		{
			// var next = Queue.ItemAfter(entity);
			Queue.Remove(entity);

			if (_current == entity)
				_current = default;
			// _current = next;
		}

		public void PutFirst(GameEntity actor)
		{
			var actorIndex = Queue.IndexOf(actor);
			Debug.Assert(actorIndex != -1, $"The queue doesn't contain the {actor}");

			Queue.RemoveAt(actorIndex);
			Queue.Insert(0, actor);

			// _current = actor;
		}
	}
}