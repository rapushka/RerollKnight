using System;
using Code.Component;
using Entitas;
using Entitas.Generic;
using Zenject;

namespace Code
{
	public sealed class ToStateForCurrentActorSystem : IInitializeSystem, IStateTransferSystem
	{
		private readonly Contexts _contexts;

		[Inject]
		public ToStateForCurrentActorSystem(Contexts contexts)
		{
			_contexts = contexts;
		}

		public StateMachineBase StateMachine { get; set; }

		private Entity<GameScope> CurrentActor => _contexts.Get<GameScope>().Unique.GetEntityOrDefault<CurrentActor>();

		public void Initialize()
		{
			if (CurrentActor.Is<Player>())
				StateMachine.ToState<ObservingGameplayState>();
			else if (CurrentActor.Is<Enemy>())
				StateMachine.ToState<WaitAndThenToState<OtherPlayerTurnGameplayState>>();
			else
				throw new InvalidOperationException($"Unknown actor entity! {CurrentActor}");
		}
	}
}