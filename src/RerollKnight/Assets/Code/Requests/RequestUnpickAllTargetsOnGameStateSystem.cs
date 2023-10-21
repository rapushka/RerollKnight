using System.Collections.Generic;
using Entitas;
using static Code.GameState;

namespace Code
{
	public sealed class RequestUnpickAllTargetsOnGameStateSystem : ReactiveSystem<GameEntity>
	{
		private readonly Contexts _contexts;

		public RequestUnpickAllTargetsOnGameStateSystem(Contexts contexts)
			: base(contexts.game)
			=> _contexts = contexts;

		protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
			=> context.CreateCollector(GameMatcher.GameState);

		protected override bool Filter(GameEntity entity)
			=> _contexts.GameStateIs(TurnEnded);

		protected override void Execute(List<GameEntity> entites) => SendRequest.UnpickAll();
	}
}