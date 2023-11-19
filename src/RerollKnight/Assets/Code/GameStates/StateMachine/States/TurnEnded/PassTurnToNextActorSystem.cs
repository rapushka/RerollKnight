using Code.Component;
using Entitas;
using Entitas.Generic;

namespace Code
{
	public sealed class PassTurnToNextActorSystem : IInitializeSystem
	{
		private readonly Contexts _contexts;
		private readonly TurnsQueue _turnsQueue;
		private readonly StateChangeBus _stateChangeBus;

		public PassTurnToNextActorSystem(Contexts contexts, TurnsQueue turnsQueue, StateChangeBus stateChangeBus)
		{
			_contexts = contexts;
			_turnsQueue = turnsQueue;
			_stateChangeBus = stateChangeBus;
		}

		private Entity<GameScope> CurrentPlayer => _contexts.Get<GameScope>().Unique.GetEntityOrDefault<CurrentActor>();

		public void Initialize()
		{
			CurrentPlayer?.Is<CurrentActor>(false);
			var actor = _turnsQueue.Next();
			actor.Is<CurrentActor>(true);

			if (actor.Is<Player>())
				_stateChangeBus.ToState<ObservingGameplayState>();
			else
				_stateChangeBus.ToState<OtherPlayerTurnGameplayState>();
		}
	}
}