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
			_queueEntity.Replace<DebugName, string>($"turns queue: [{ToString(_turnsQueue.AllActors)}]");
		}

		private string ToString(IEnumerable<Entity<GameScope>> list)
		{
			return string.Join(", ", list.Select(ToString));
		}

		private string ToString(Entity<GameScope> entity)
		{
			var body = $"{entity.creationIndex}_{entity.Get<DebugName>().Value}";

			return entity.Is<CurrentActor>() ? $">{body}<" : body;
		}
	}
}