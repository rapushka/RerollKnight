using System.Collections.Generic;
using Entitas;
using static ChipsMatcher;

namespace Code
{
	public sealed class CastTeleportSystem : ReactiveSystem<ChipsEntity>
	{
		private readonly IGroup<GameEntity> _players;
		private readonly IGroup<GameEntity> _targets;

		public CastTeleportSystem(Contexts contexts)
			: base(contexts.chips)
		{
			_players = contexts.game.GetGroup(GameMatcher.Player);
			_targets = contexts.game.GetGroup(GameMatcher.PickedTarget);
		}

		protected override ICollector<ChipsEntity> GetTrigger(IContext<ChipsEntity> context)
			=> context.CreateCollector(AllOf(Casted, Teleport));

		protected override bool Filter(ChipsEntity entity) => entity.isCasted;

		protected override void Execute(List<ChipsEntity> entites)
		{
			foreach (var player in _players)
			foreach (var target in _targets)
			{
				player.ReplaceCoordinates(target.coordinatesUnderField.Value);
			}
		}
	}
}