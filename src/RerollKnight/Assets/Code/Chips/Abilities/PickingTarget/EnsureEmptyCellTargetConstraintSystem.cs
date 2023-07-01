using System.Collections.Generic;
using Entitas;

namespace Code
{
	public sealed class EnsureEmptyCellTargetConstraintSystem : ReactiveSystem<GameEntity>
	{
		public EnsureEmptyCellTargetConstraintSystem(Contexts contexts) : base(contexts.game) { }

		protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
			=> context.CreateCollector(GameMatcher.PickedTarget);

		protected override bool Filter(GameEntity entity) => true;

		protected override void Execute(List<GameEntity> entites)
		{
			foreach (GameEntity e in entites) { }
		}
	}
}