using Code.Component;
using Entitas;
using Entitas.Generic;

namespace Code
{
	public sealed class PassTurnToNextPlayerSystem : IInitializeSystem
	{
		private readonly Contexts _contexts;
		private readonly TurnsQueue _turnsQueue;
		private readonly StateChangeBus _stateChangeBus;

		public PassTurnToNextPlayerSystem(Contexts contexts, TurnsQueue turnsQueue, StateChangeBus stateChangeBus)
		{
			_contexts = contexts;
			_turnsQueue = turnsQueue;
			_stateChangeBus = stateChangeBus;
		}

		private Entity<GameScope> CurrentPlayer => _contexts.Get<GameScope>().Unique.GetEntity<CurrentPlayer>();

		public void Initialize()
		{
			CurrentPlayer.Is<CurrentPlayer>(false);
			var entity = _turnsQueue.Next();
			entity.Is<CurrentPlayer>(true);

			if (entity.Is<Player>())
				_stateChangeBus.ToState<ObservingGameState>();
			else
				_stateChangeBus.ToState<OtherPlayerTurnGameState>();
		}
	}
}