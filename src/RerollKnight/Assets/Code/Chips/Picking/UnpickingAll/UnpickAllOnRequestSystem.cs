using Entitas;
using static GameMatcher;
using static RequestMatcher;

namespace Code
{
	public sealed class UnpickAllOnRequestSystem : FulfillRequestSystemBase
	{
		private readonly IGroup<GameEntity> _targets;

		public UnpickAllOnRequestSystem(Contexts contexts) : base(contexts)
			=> _targets = contexts.game.GetGroup(PickedTarget);

		protected override IMatcher<RequestEntity> Request => UnpickAllTargets;

		protected override void OnRequest()
		{
			foreach (var e in _targets.GetEntities())
				e.Unpick();
		}
	}
}