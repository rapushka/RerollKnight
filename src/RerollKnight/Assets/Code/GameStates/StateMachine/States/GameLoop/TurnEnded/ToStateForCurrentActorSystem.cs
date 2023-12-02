using System;
using Code.Component;
using Entitas;
using Entitas.Generic;
using Zenject;

namespace Code
{
	public sealed class ToStateForCurrentActorSystem : IInitializeSystem
	{
		private readonly Contexts _contexts;
		private readonly StateChangeBus _stateChangeBus;

		[Inject]
		public ToStateForCurrentActorSystem(Contexts contexts, StateChangeBus stateChangeBus)
		{
			_contexts = contexts;
			_stateChangeBus = stateChangeBus;
		}

		private Entity<GameScope> CurrentActor => _contexts.Get<GameScope>().Unique.GetEntityOrDefault<CurrentActor>();

		public void Initialize()
		{
			if (CurrentActor.Is<Player>())
				_stateChangeBus.ToState<ObservingGameplayState>();
			else if (CurrentActor.Is<Enemy>())
				_stateChangeBus.ToState<WaitAndThenToState<OtherPlayerTurnGameplayState>>();
			else
				throw new InvalidOperationException($"Unknown actor entity! {CurrentActor}");
		}
	}
}