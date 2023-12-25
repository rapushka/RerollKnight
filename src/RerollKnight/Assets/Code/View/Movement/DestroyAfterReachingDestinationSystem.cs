using System.Collections.Generic;
using Code.Component;
using Entitas;
using Entitas.Generic;
using static Entitas.Generic.ScopeMatcher<Code.GameScope>;

namespace Code
{
	public sealed class DestroyAfterReachingDestinationSystem : ReactiveSystem<Entity<GameScope>>
	{
		public DestroyAfterReachingDestinationSystem(Contexts contexts) : base(contexts.Get<GameScope>()) { }

		protected override ICollector<Entity<GameScope>> GetTrigger(IContext<Entity<GameScope>> context)
			=> context.CreateCollector(Get<DestinationPosition>().AddedOrRemoved());

		protected override bool Filter(Entity<GameScope> entity)
			=> entity.Is<DestroyAfterReachingDestination>() && !entity.Has<DestinationPosition>();

		protected override void Execute(List<Entity<GameScope>> entities)
		{
			foreach (var e in entities)
				e.Is<Destroyed>(true);
		}
	}
}