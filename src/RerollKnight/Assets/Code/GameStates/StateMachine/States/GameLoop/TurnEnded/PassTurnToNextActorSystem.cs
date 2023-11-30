using System.Diagnostics.CodeAnalysis;
using Code.Component;
using Entitas;
using Entitas.Generic;
using Zenject;

namespace Code
{
	public sealed class PassTurnToNextActorSystem : IInitializeSystem
	{
		private readonly TurnsQueue _turnsQueue;
		private readonly StateChangeBus _stateChangeBus;
		private readonly Contexts _contexts;

		[Inject]
		public PassTurnToNextActorSystem(Contexts contexts, TurnsQueue turnsQueue, StateChangeBus stateChangeBus)
		{
			_contexts = contexts;
			_turnsQueue = turnsQueue;
			_stateChangeBus = stateChangeBus;
		}

		[AllowNull]
		private Entity<GameScope> CurrentPlayer => _contexts.Get<GameScope>().Unique.GetEntityOrDefault<CurrentActor>();

		public void Initialize()
		{
			CurrentPlayer?.Is<CurrentActor>(false);
			var actor = _turnsQueue.Next();
			actor.Is<CurrentActor>(true);

			if (actor.Is<Player>())
				_stateChangeBus.ToState<ObservingGameplayState>();
			else
				_stateChangeBus.ToState<WaitAndThenToState<OtherPlayerTurnGameplayState>>();
		}
	}
}