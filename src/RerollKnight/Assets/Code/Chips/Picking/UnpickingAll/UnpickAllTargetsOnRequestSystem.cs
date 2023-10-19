using System.Collections.Generic;
using Entitas;
using static GameMatcher;
using static RequestMatcher;

namespace Code
{
	public sealed class UnpickAllTargetsOnRequestSystem : ReactiveSystem<RequestEntity>
	{
		private readonly IGroup<GameEntity> _targets;

		public UnpickAllTargetsOnRequestSystem(Contexts contexts)
			: base(contexts.request)
			=> _targets = contexts.game.GetGroup(PickedTarget);

		protected override ICollector<RequestEntity> GetTrigger(IContext<RequestEntity> context)
			=> context.CreateCollector(UnpickAllTargets);

		protected override bool Filter(RequestEntity entity) => true;

		protected override void Execute(List<RequestEntity> entites)
		{
			foreach (var e in _targets.GetEntities())
			{
				e.Unpick();
			}
		}
	}
}