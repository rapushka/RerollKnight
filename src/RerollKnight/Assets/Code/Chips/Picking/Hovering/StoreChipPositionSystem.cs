using System.Collections.Generic;
using Entitas;
using static GameMatcher;

namespace Code
{
	public sealed class StoreChipPositionSystem : ReactiveSystem<GameEntity>
	{
		public StoreChipPositionSystem(Contexts contexts) : base(contexts.game) { }

		protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
			=> context.CreateCollector(AllOf(Chip, Position).NoneOf(InitialPosition));

		protected override bool Filter(GameEntity entity) => true;

		protected override void Execute(List<GameEntity> entites)
		{
			foreach (var e in entites)
			{
				e.ReplaceInitialPosition(e.position.Value);
			}
		}
	}
}