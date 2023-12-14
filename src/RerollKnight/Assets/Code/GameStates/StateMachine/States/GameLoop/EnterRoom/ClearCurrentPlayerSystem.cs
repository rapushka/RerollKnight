using Code.Component;
using Entitas;
using Entitas.Generic;

namespace Code
{
	public class ClearCurrentPlayerSystem : IInitializeSystem
	{
		private readonly Contexts _contexts;
		private readonly TurnsQueue _turnsQueue;

		public ClearCurrentPlayerSystem(Contexts contexts, TurnsQueue turnsQueue)
		{
			_contexts = contexts;
			_turnsQueue = turnsQueue;
		}

		private Entity<GameScope> CurrentActor => _contexts.Get<GameScope>().Unique.GetEntity<CurrentActor>();

		public void Initialize()
		{
			CurrentActor.Is<CurrentActor>(false);
			_turnsQueue.Reset();
		}
	}
}