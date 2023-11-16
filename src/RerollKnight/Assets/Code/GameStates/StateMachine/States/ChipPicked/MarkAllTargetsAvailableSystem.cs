using Code.Component;
using Entitas;
using Entitas.Generic;

namespace Code
{
	public sealed class MarkAllTargetsAvailableSystem : IInitializeSystem
	{
		private readonly IGroup<Entity<GameScope>> _targets;

		public MarkAllTargetsAvailableSystem(Contexts contexts)
		{
			_targets = contexts.GetGroup(ScopeMatcher<GameScope>.Get<Target>());
		}

		public void Initialize()
		{
			foreach (var e in _targets)
				e.Is<AvailableToPick>(true);
		}
	}
}