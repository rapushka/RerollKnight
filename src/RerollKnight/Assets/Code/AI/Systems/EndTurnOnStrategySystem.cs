using Code.Component;
using Entitas;
using Entitas.Generic;

namespace Code
{
	public sealed class EndTurnOnStrategySystem : IInitializeSystem, IStateTransferSystem
	{
		private readonly Contexts _contexts;

		public EndTurnOnStrategySystem(Contexts contexts)
		{
			_contexts = contexts;
		}

		public StateMachineBase StateMachine { get; set; }

		private Entity<GameScope> CurrentActor => _contexts.Get<GameScope>().Unique.GetEntity<CurrentActor>();

		public void Initialize()
		{
			if (CurrentActor.Get<CurrentStrategy>().Value is EnemyStrategy.EndTurn)
				StateMachine.ToState<TurnEndedGameplayState>();
		}
	}
}