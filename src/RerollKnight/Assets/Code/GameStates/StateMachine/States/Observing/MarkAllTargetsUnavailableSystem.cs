using Code.Component;
using Entitas;
using Entitas.Generic;

namespace Code
{
	public sealed class MarkAllTargetsUnavailableSystem : IInitializeSystem
	{
		private readonly IGroup<Entity<GameScope>> _targets;

		public MarkAllTargetsUnavailableSystem(Contexts contexts)
		{
			_targets = contexts.GetGroup(ScopeMatcher<GameScope>.Get<Target>());
		}

		public void Initialize()
		{
			foreach (var e in _targets)
				e.Is<AvailableToPick>(false);
		}
	}
}