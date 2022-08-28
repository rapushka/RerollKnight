using System.Collections.Generic;
using Entitas;

namespace Code.Ecs.Systems.View.Initialization
{
	public sealed class MoveViewToInitialPositionSystem : ReactiveSystem<GameEntity>
	{
		public MoveViewToInitialPositionSystem(Contexts contexts)
			: base(contexts.game) { }

		protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
			=> context.CreateCollector(GameMatcher.ViewController.Added());

		protected override bool Filter(GameEntity entity)
			=> entity.hasPosition && entity.hasTransform;

		protected override void Execute(List<GameEntity> entites)
			=> entites.ForEach(Move);

		private static void Move(GameEntity e)
			=> e.transform.Value.position = e.position;
	}
}