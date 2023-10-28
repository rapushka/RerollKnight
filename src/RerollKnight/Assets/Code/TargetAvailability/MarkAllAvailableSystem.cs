using Entitas;
using Zenject;
using static RequestMatcher;

namespace Code
{
	public sealed class MarkAllAvailableSystem : FulfillRequestSystemBase
	{
		private readonly IGroup<GameEntity> _targets;

		[Inject]
		public MarkAllAvailableSystem(Contexts contexts) : base(contexts)
			=> _targets = contexts.game.GetGroup(GameMatcher.Target);

		protected override IMatcher<RequestEntity> Request => MarkAllTargetsAvailable;

		protected override void OnRequest()
		{
			foreach (var e in _targets)
				e.isAvailableToPick = true;
		}
	}
}