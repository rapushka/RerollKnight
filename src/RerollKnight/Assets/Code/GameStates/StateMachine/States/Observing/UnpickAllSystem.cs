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

		private Entity<GameScope> PickedChip => _contexts.Get<GameScope>().Unique.GetEntityOrDefault<PickedChip>();

		public void Initialize()
		{
			if (PickedChip is not null)
			{
				UnpickAbilities();
				PickedChip.Unpick();
			}

			UnpickTargets();
		}

		private void UnpickAbilities()
		{
			foreach (var ability in PickedChip.GetAbilities())
				ability.Replace<Component.AbilityState, AbilityState>(AbilityState.Inactive);
		}

		private void UnpickTargets()
		{
			foreach (var target in _targets.GetEntities())
				target.Unpick();
		}
	}
}