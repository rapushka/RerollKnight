using System.Collections.Generic;
using Entitas;

namespace Code
{
	public sealed class UnpickAllOnTurnEndedSystem : ReactiveSystem<GameEntity>
	{
		private readonly GameContext _context;
		private readonly IGroup<GameEntity> _targets;

		public UnpickAllOnTurnEndedSystem(Contexts contexts) : base(contexts.game)
		{
			_context = contexts.game;
			_targets = _context.GetGroup(GameMatcher.PickedTarget);
		}

		protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
			=> context.CreateCollector(GameMatcher.GameState);

		protected override bool Filter(GameEntity entity) => entity.gameState.Value is GameState.TurnEnded;

		protected override void Execute(List<GameEntity> entites)
		{
			_context.pickedChipEntity.Unpick();

			foreach (var target in _targets.GetEntities())
				target.Unpick();
		}
	}
}