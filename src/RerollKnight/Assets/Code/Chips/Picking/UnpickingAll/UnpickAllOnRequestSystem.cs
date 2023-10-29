using Entitas;

namespace Code
{
	public sealed class UnpickAllOnRequestSystem : FulfillRequestSystemBase
	{
		private readonly IGroup<GameEntity> _targets;

		public UnpickAllOnRequestSystem(Contexts contexts) : base(contexts)
			=> _targets = contexts.game.GetGroup(GameMatcher.PickedTarget);

		protected override IMatcher<RequestEntity> Request => RequestMatcher.UnpickAllTargets;

		protected override void OnRequest(RequestEntity request)
		{
			foreach (var e in _targets.GetEntities())
				e.Unpick();
		}
	}
}