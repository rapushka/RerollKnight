using System.Collections.Generic;
using Entitas;
using Entitas.Generic;
using ChipsMatcher = Entitas.Generic.ScopeMatcher<Code.ChipsScope>;
using GameMatcher = Entitas.Generic.ScopeMatcher<Code.GameScope>;

namespace Code
{
	public sealed class PrepareAbilitiesOfPickedChipSystem : ReactiveSystem<Entity<GameScope>>
	{
		private readonly Contexts _contexts;
		private readonly IGroup<Entity<ChipsScope>> _abilities;

		public PrepareAbilitiesOfPickedChipSystem(Contexts contexts) : base(contexts.Get<GameScope>())
		{
			_contexts = contexts;
			_abilities = contexts.GetGroup(ChipsMatcher.Get<AbilityOfChip>());
		}

		private bool HasPickedChip => _contexts.Get<GameScope>().Unique.Has<PickedChip>();

		private Entity<GameScope> PickedChip => _contexts.Get<GameScope>().Unique.GetEntity<PickedChip>();

		protected override ICollector<Entity<GameScope>> GetTrigger(IContext<Entity<GameScope>> context)
			=> context.CreateCollector(GameMatcher.Get<PickedChip>().AddedOrRemoved());

		protected override bool Filter(Entity<GameScope> entity) => true;

		protected override void Execute(List<Entity<GameScope>> entites)
		{
			foreach (var ability in _abilities)
			{
				var ourChipIsPicked = HasPickedChip && ability.IsOwnedBy(PickedChip);
				ability.Replace<State, AbilityState>(ourChipIsPicked ? AbilityState.Prepared : AbilityState.Inactive);
			}
		}
	}
}