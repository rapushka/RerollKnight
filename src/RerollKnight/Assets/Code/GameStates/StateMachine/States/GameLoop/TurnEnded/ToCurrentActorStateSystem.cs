using System;
using Code.Component;
using Entitas;
using Entitas.Generic;
using Zenject;

namespace Code
{
	public sealed class ToCurrentActorStateSystem : IStateTransferSystem, IInitializeSystem
	{
		private readonly Contexts _contexts;
		private readonly IViewConfig _viewConfig;

		[Inject]
		private ToCurrentActorStateSystem(Contexts contexts, IViewConfig viewConfig)
		{
			_contexts = contexts;
			_viewConfig = viewConfig;
		}

		public StateMachineBase StateMachine { get; set; }

		private Entity<GameScope> CurrentActor => _contexts.Get<GameScope>().Unique.GetEntityOrDefault<CurrentActor>();

		public void Initialize()
		{
			ChangeState();
		}

		private void ChangeState()
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