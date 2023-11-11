using Code.Component;
using Entitas;
using Entitas.Generic;

namespace Code
{
	public sealed class UnpickAllSystem : IInitializeSystem
	{
		private readonly IGroup<Entity<GameScope>> _targets;
		private readonly Contexts _contexts;

		public UnpickAllSystem(Contexts contexts)
		{
			_contexts = contexts;
			_targets = _contexts.GetGroup(ScopeMatcher<GameScope>.Get<PickedTarget>());
		}

		public void Initialize()
		{
			_contexts.Get<GameScope>().Unique.GetEntityOrDefault<PickedChip>()?.Unpick();

			foreach (var e in _targets.GetEntities())
				e.Unpick();
		}
	}
}