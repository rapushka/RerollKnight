using Entitas;
using Entitas.Generic;
using Zenject;

namespace Code
{
	public sealed class SetAllAvailabilitySystem : FulfillRequestSystemBase
	{
		private readonly IGroup<Entity<GameScope>> _targets;

		[Inject]
		public SetAllAvailabilitySystem(Contexts contexts) : base(contexts)
			=> _targets = contexts.GetGroup(ScopeMatcher<GameScope>.Get<Target>());

		protected override IMatcher<Entity<RequestScope>> Request
			=> ScopeMatcher<RequestScope>.Get<SetAllTargetsAvailability>();

		protected override void OnRequest(Entity<RequestScope> request)
		{
			foreach (var e in _targets)
				e.Is<AvailableToPick>(request.Get<SetAllTargetsAvailability>().Value);
		}
	}
}