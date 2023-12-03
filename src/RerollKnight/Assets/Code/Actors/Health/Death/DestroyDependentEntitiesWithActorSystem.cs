using System.Collections.Generic;
using Code.Component;
using Entitas;
using Entitas.Generic;
using static Entitas.Generic.ScopeMatcher<Code.GameScope>;

namespace Code
{
	public sealed class DestroyDependentEntitiesWithActorSystem : ReactiveSystem<Entity<GameScope>>
	{
		public DestroyDependentEntitiesWithActorSystem(Contexts contexts) : base(contexts.Get<GameScope>()) { }

		protected override ICollector<Entity<GameScope>> GetTrigger(IContext<Entity<GameScope>> context)
			=> context.CreateCollector(AllOf(Get<Actor>(), Get<Destroyed>()));

		protected override bool Filter(Entity<GameScope> entity) => entity.Is<Destroyed>();

		protected override void Execute(List<Entity<GameScope>> entities)
		{
			foreach (var actor in entities)
			{
				var chips = BelongToActor.Index.GetEntities(actor.Get<ID>().Value);
				DestroyAllChips(chips);
				actor.Is<Destroyed>(true);
			}
		}

		private static void DestroyAllChips(HashSet<Entity<GameScope>> chips)
		{
			foreach (var chip in chips)
			{
				if (chip.Is<Chip>())
				{
					var abilities = AbilityOfChip.Index.GetEntities(chip.Get<ID>().Value);
					DestroyAllAbilities(abilities);
				}

				chip.Is<Destroyed>(true);
			}
		}

		private static void DestroyAllAbilities(HashSet<Entity<ChipsScope>> abilities)
		{
			foreach (var ability in abilities)
				ability.Is<Destroyed>(true);
		}
	}
}