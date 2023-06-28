using System.Collections.Generic;
using Entitas;
using static GameMatcher;

namespace Code
{
	public sealed class UnhoverUnpickedChipSystem : ReactiveSystem<GameEntity>
	{
		public UnhoverUnpickedChipSystem(Contexts contexts) : base(contexts.game) { }

		protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
			=> context.CreateCollector(AllOf(PickedChip, Position));

		protected override bool Filter(GameEntity entity) => entity.isPickedChip == false;

		protected override void Execute(List<GameEntity> entites)
		{
			foreach (var e in entites)
			{
				e.ReplaceDestinationPosition(e.initialPosition.Value);
			}
		}
	}
}