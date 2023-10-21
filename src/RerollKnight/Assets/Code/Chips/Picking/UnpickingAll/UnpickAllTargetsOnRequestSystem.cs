using Entitas;
using static GameMatcher;
using static RequestMatcher;

namespace Code
{
	public sealed class UnpickAllTargetsOnRequestSystem : FulfillRequestSystemBase
	{
		private readonly IGroup<GameEntity> _targets;
		private readonly Contexts _contexts;

		public UnpickAllTargetsOnRequestSystem(Contexts contexts) : base(contexts)
		{
			_contexts = contexts;
			_targets = _contexts.game.GetGroup(PickedTarget);
		}

		protected override IMatcher<RequestEntity> Request => UnpickAllTargets;

		protected override void OnRequest()
		{
			_contexts.game.pickedChipEntity?.Unpick();

			foreach (var e in _targets.GetEntities())
				e.Unpick();
		}
	}
}