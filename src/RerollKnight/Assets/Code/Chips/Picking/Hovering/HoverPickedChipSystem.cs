using System.Collections.Generic;
using Entitas;
using static GameMatcher;

namespace Code
{
	public sealed class HoverPickedChipSystem : ReactiveSystem<GameEntity>
	{
		private readonly ILayoutService _layoutService;

		public HoverPickedChipSystem(Contexts contexts, ILayoutService layoutService)
			: base(contexts.game)
		{
			_layoutService = layoutService;
		}

		protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
			=> context.CreateCollector(AllOf(PickedChip, Position));

		protected override bool Filter(GameEntity entity) => entity.isPickedChip;

		protected override void Execute(List<GameEntity> entites)
		{
			foreach (var e in entites)
			{
				e.ReplaceDestinationPosition(e.initialPosition.Value + _layoutService.PickingChipOffset);
			}
		}
	}
}