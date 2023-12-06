using System.Collections.Generic;
using Code.Component;
using Entitas;
using Entitas.Generic;

namespace Code
{
	public sealed class DestroyWithDependentsSystem<TScope> : ReactiveSystem<Entity<TScope>> where TScope : IScope
	{
		public DestroyWithDependentsSystem(Contexts contexts) : base(contexts.Get<TScope>()) { }

		protected override ICollector<Entity<TScope>> GetTrigger(IContext<Entity<TScope>> context)
			=> context.CreateCollector(ScopeMatcher<TScope>.AllOf(ID, Destroyed));

		private static IMatcher<Entity<TScope>> ID => ScopeMatcher<TScope>.Get<ID>();

		private static IMatcher<Entity<TScope>> Destroyed => ScopeMatcher<TScope>.Get<Destroyed>();

		protected override bool Filter(Entity<TScope> entity) => entity.Is<Destroyed>();

		protected override void Execute(List<Entity<TScope>> entities)
		{
			foreach (var entity in entities)
				DestroyAllDependant(entity);
		}

		private void DestroyAllDependant<TScope1>(Entity<TScope1> entity)
			where TScope1 : IScope
		{
			DestroyDependant<TScope1, GameScope>(entity);
			DestroyDependant<TScope1, ChipsScope>(entity);
			DestroyDependant<TScope1, RequestScope>(entity);
		}

		private void DestroyDependant<TScope1, TScope2>(Entity<TScope1> entity)
			where TScope1 : IScope
			where TScope2 : IScope
		{
			foreach (var e in ForeignID.GetIndex<TScope2>().GetEntities(entity.Get<ID>().Value))
			{
				DestroyAllDependant(e);
				e.Is<Destroyed>(true);
			}
		}
	}
}