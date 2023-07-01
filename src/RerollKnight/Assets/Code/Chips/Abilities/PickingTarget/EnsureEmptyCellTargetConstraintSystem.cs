using System.Collections.Generic;
using Entitas;

namespace Code
{
	public sealed class EnsureEmptyCellTargetConstraintSystem : ReactiveSystem<GameEntity>
	{
		private Contexts _contexts;
		public EnsureEmptyCellTargetConstraintSystem(Contexts contexts) : base(contexts.game) => _contexts = contexts;

		protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
			=> context.CreateCollector(GameMatcher.PickedTarget);

		protected override bool Filter(GameEntity entity) => entity.isPickedTarget;

		protected override void Execute(List<GameEntity> entites)
		{

			foreach (var e in entites) { }
		}
	}
}