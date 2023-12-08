using System.Diagnostics.CodeAnalysis;
using Code.Component;
using Entitas;
using Entitas.Generic;
using Zenject;

namespace Code
{
	public sealed class PrepareAbilitiesOfPickedChipSystem : IInitializeSystem
	{
		private readonly Contexts _contexts;

		[Inject]
		public PrepareAbilitiesOfPickedChipSystem(Contexts contexts)
		{
			_contexts = contexts;
		}

		[AllowNull]
		private Entity<GameScope> PickedChip => _contexts.Get<GameScope>().Unique.GetEntityOrDefault<PickedChip>();

		public void Initialize()
		{
			if (PickedChip is null)
				return;

			foreach (var ability in PickedChip.GetAbilities())
				ability.Replace<Component.AbilityState, AbilityState>(AbilityState.Prepared);
		}
	}
}