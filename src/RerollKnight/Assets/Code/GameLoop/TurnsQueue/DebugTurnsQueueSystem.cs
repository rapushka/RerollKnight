using System.Collections.Generic;
using System.Linq;
using Code.Component;
using Entitas;
using Entitas.Generic;

namespace Code
{
	public sealed class DebugTurnsQueueSystem : IInitializeSystem, IExecuteSystem
	{
		private readonly Contexts _contexts;
		private readonly TurnsQueue _turnsQueue;

		private Entity<GameScope> _queueEntity;

		public DebugTurnsQueueSystem(Contexts contexts, TurnsQueue turnsQueue)
		{
			_contexts = contexts;
			_turnsQueue = turnsQueue;
		}

		public void Initialize()
		{
			_queueEntity = _contexts.Get<GameScope>().CreateEntity();
		}

		public void Execute()
		{
			_queueEntity.Replace<DebugName, string>($"turns queue: [{ToString(_turnsQueue.Queue)}]");
		}

		private string ToString(IEnumerable<Entity<GameScope>> list)
		{
			return string.Join(", ", list.Select(ToString));
		}

		private string ToString(Entity<GameScope> entity, int index)
		{
			var nextActor = _turnsQueue.Queue.First();
			var indexOfCurrent = _turnsQueue.AllActors.IndexOf(nextActor) - 1;

			if (indexOfCurrent == -1)
				indexOfCurrent = _turnsQueue.AllActors.Count;

			var isCurrent = indexOfCurrent == index;

			var body = $"{entity.creationIndex}_{entity.Get<DebugName>().Value}";

			return isCurrent
				? $">{body}<"
				: body;
		}
	}
}