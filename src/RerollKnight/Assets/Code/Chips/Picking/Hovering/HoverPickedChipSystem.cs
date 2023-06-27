using System.Collections.Generic;
using Entitas;
using static GameMatcher;

namespace Code
{
	public sealed class HoverPickedChipSystem : ReactiveSystem<GameEntity>
	{
		public HoverPickedChipSystem(Contexts contexts) : base(contexts.game) { }

		protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
			=> context.CreateCollector(AllOf(PickedChip));

		protected override bool Filter(GameEntity entity) => true;

		protected override void Execute(List<GameEntity> entites)
		{
			foreach (var e in entites)
			{
				
			}
		}
	}
}