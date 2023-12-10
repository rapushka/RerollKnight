using System;
using Code.Component;
using Entitas.Generic;
using Zenject;

namespace Code
{
	public abstract class ToCurrentActorStateSystem : IStateTransferSystem
	{
		private readonly Contexts _contexts;
		private readonly IViewConfig _viewConfig;

		[Inject]
		protected ToCurrentActorStateSystem(Contexts contexts, IViewConfig viewConfig)
		{
			_contexts = contexts;
			_viewConfig = viewConfig;
		}

		public StateMachineBase StateMachine { get; set; }

		private Entity<GameScope> CurrentActor => _contexts.Get<GameScope>().Unique.GetEntityOrDefault<CurrentActor>();

		protected void ChangeState()
		{
			if (CurrentActor.Is<Player>())
				StateMachine.ToState<ObservingGameplayState>();
			else if (CurrentActor.Is<Enemy>())
				StateMachine.ToState<WaitAndThenToState, WaitAndThenToState.Data>(ToOtherPlayerTurnState);
			else
				throw new InvalidOperationException($"Unknown actor entity! {CurrentActor}");
		}

		private WaitAndThenToState.Data ToOtherPlayerTurnState
			=> WaitAndThenToState.To<OtherPlayerTurnGameplayState>(after: _viewConfig.EnemyThinkingDuration);
	}
}