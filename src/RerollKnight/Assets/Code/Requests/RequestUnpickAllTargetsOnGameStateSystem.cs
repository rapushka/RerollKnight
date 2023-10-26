using System;
using System.Collections.Generic;
using Entitas;

namespace Code
{
	public sealed class RequestUnpickAllTargetsOnGameStateSystem : ReactiveSystem<GameEntity>
	{
		public RequestUnpickAllTargetsOnGameStateSystem(Contexts contexts)
			: base(contexts.game) { }

		protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
			=> throw new NotImplementedException();
		// => context.CreateCollector(GameMatcher.GameState);

		protected override bool Filter(GameEntity entity)
			=> ServicesMediator.GameStateMachine.CurrentState is TurnEndedGameState;

		protected override void Execute(List<GameEntity> entites) => SendRequest.UnpickAll();
	}
}