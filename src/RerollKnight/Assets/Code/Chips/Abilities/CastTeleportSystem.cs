using System.Collections.Generic;
using Entitas;
using static ChipsMatcher;

namespace Code
{
	public sealed class CastTeleportSystem : ReactiveSystem<ChipsEntity>
	{
		private readonly IGroup<GameEntity> _players;

		public CastTeleportSystem(Contexts contexts)
			: base(contexts.chips)
			=> _players = contexts.game.GetGroup(GameMatcher.Player);

		protected override ICollector<ChipsEntity> GetTrigger(IContext<ChipsEntity> context)
			=> context.CreateCollector(AllOf(Casted, Teleport));

		protected override bool Filter(ChipsEntity entity) => entity.isCasted;

		protected override void Execute(List<ChipsEntity> entites)
		{
			foreach (var player in _players)
			foreach (var target in entites.SelectTargets())
			{
				player.ReplaceCoordinates(target.coordinatesUnderField.Value);
			}
		}
	}
}