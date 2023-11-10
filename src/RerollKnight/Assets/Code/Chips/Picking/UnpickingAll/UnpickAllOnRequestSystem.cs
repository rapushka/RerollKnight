using Code.Component;
using Entitas;
using Entitas.Generic;
using GameMatcher = Entitas.Generic.ScopeMatcher<Code.GameScope>;
using RequestMatcher = Entitas.Generic.ScopeMatcher<Code.RequestScope>;

namespace Code
{
	public sealed class UnpickAllOnRequestSystem : FulfillRequestSystemBase
	{
		private readonly IGroup<Entity<GameScope>> _targets;

		public UnpickAllOnRequestSystem(Contexts contexts) : base(contexts)
			=> _targets = contexts.Get<GameScope>().GetGroup(GameMatcher.Get<PickedTarget>());

		protected override IMatcher<Entity<RequestScope>> Request => RequestMatcher.Get<UnpickAllTargets>();

		protected override void OnRequest(Entity<RequestScope> request)
		{
			foreach (var e in _targets.GetEntities())
				e.Unpick();
		}
	}
}