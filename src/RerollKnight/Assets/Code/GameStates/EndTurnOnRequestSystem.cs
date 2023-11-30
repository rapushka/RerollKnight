using Code.Component;
using Entitas.Generic;

namespace Code
{
	public sealed class EndTurnOnRequestSystem : FulfillRequestSystemBase<EndTurn>
	{
		private readonly IStateChangeBus _stateChangeBus;

		public EndTurnOnRequestSystem(Contexts contexts, IStateChangeBus stateChangeBus)
			: base(contexts)
			=> _stateChangeBus = stateChangeBus;

		protected override void OnRequest(Entity<RequestScope> request)
		{
			_stateChangeBus.ToState<TurnEndedGameplayState>();
		}
	}
}