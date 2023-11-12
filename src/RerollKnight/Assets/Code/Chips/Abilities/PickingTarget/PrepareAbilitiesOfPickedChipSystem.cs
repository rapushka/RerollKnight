using System.Collections.Generic;
using Code.Component;
using Entitas;
using Entitas.Generic;
using GameMatcher = Entitas.Generic.ScopeMatcher<Code.GameScope>;

namespace Code
{
	public sealed class PrepareAbilitiesOfPickedChipSystem : ReactiveSystem<Entity<GameScope>>
	{
		private readonly Contexts _contexts;

		public PrepareAbilitiesOfPickedChipSystem(Contexts contexts)
			: base(contexts.Get<GameScope>())
		{
			_contexts = contexts;
		}

		private Entity<GameScope> PickedChip => _contexts.Get<GameScope>().Unique.GetEntity<PickedChip>();

		protected override ICollector<Entity<GameScope>> GetTrigger(IContext<Entity<GameScope>> context)
			=> context.CreateCollector(GameMatcher.Get<PickedChip>().Added());

		protected override bool Filter(Entity<GameScope> entity) => entity.Has<PickedChip>();

		protected override void Execute(List<Entity<GameScope>> entites)
		{
			foreach (var ability in PickedChip.GetAbilities())
				ability.Replace<Component.AbilityState, AbilityState>(AbilityState.Prepared);
		}
	}
}