using System.Collections.Generic;
using Entitas;
using static Code.OutlineParams;

namespace Code
{
	public sealed class OutlineAvailableTargetsSystem : ReactiveSystem<GameEntity>
	{
		public OutlineAvailableTargetsSystem(Contexts contexts) : base(contexts.game) { }

		protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
			=> context.CreateCollector(GameMatcher.AvailableToPick);

		protected override bool Filter(GameEntity entity) => true;

		protected override void Execute(List<GameEntity> entites)
		{
			foreach (var e in entites)
				e.ReplaceOutline(new OutlineParams(Type.Available, e.isAvailableToPick));
		}
	}
}