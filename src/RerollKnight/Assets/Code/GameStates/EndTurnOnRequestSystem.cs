using Code.Component;
using Entitas.Generic;

namespace Code
{
	public sealed class EndTurnOnRequestSystem : FulfillRequestSystemBase<EndTurn>
	{
		private readonly GameplayStateMachine _stateMachine;

		public EndTurnOnRequestSystem(Contexts contexts, GameplayStateMachine stateMachine)
			: base(contexts)
			=> _stateMachine = stateMachine;

		protected override void OnRequest(Entity<RequestScope> request)
		{
			_stateMachine.ToState<TurnEndedGameplayState>();
		}
	}
}