using Code.Component;
using Entitas;
using Entitas.Generic;
using Zenject;
using GameMatcher = Entitas.Generic.ScopeMatcher<Code.GameScope>;

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

		private Entity<GameScope> PickedChip => _contexts.Get<GameScope>().Unique.GetEntity<PickedChip>();

		public void Initialize()
		{
			foreach (var ability in PickedChip.GetAbilities())
				ability.Replace<Component.AbilityState, AbilityState>(AbilityState.Prepared);
		}
	}
}