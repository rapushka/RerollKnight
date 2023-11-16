using Code.Component;
using Entitas;
using Entitas.Generic;
using JetBrains.Annotations;

namespace Code
{
	public sealed class UnpickAllAbilitiesSystem : IInitializeSystem
	{
		private readonly Contexts _contexts;

		public UnpickAllAbilitiesSystem(Contexts contexts)
		{
			_contexts = contexts;
		}

		[CanBeNull]
		private Entity<GameScope> PickedChip => _contexts.Get<GameScope>().Unique.GetEntityOrDefault<PickedChip>();

		public void Initialize()
		{
			if (PickedChip is null)
				return;

			foreach (var ability in PickedChip.GetAbilities())
				ability.Replace<Component.AbilityState, AbilityState>(AbilityState.Inactive);
		}
	}
}