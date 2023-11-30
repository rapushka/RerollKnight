using System.Collections.Generic;
using Code.Component;
using Entitas;
using Entitas.Generic;
using Zenject;
using static Entitas.Generic.ScopeMatcher<Code.GameScope>;
using GameEntity = Entitas.Generic.Entity<Code.GameScope>;

namespace Code
{
	public class Query
	{
		private readonly Contexts _contexts;
		private readonly IGroup<GameEntity> _chips;

		[Inject]
		public Query(Contexts contexts)
		{
			_contexts = contexts;
			_chips = contexts.GetGroup(Get<Chip>());
		}

		public IEnumerable<GameEntity> ChipsOfCurrentActor => _chips.Where(IsBelongToCurrentActor);

		private GameEntity CurrentActor => Unique<GameScope>().GetEntity<CurrentActor>();

		private UniqueComponentsContainer<T> Unique<T>()
			where T : IScope
			=> _contexts.Get<T>().Unique;

		public bool IsBelongToCurrentActor(Entity<GameScope> chip)
			=> chip.IsBelongTo(CurrentActor);
	}
}