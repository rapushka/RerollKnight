using System.Collections.Generic;
using Code.Component;
using Entitas;
using Entitas.Generic;

namespace Code
{
	public sealed class CascadeDisableSystem<TScope> : ReactiveSystem<Entity<TScope>>
		where TScope : IScope
	{
		public CascadeDisableSystem(Contexts contexts) : base(contexts.Get<TScope>()) { }

		protected override ICollector<Entity<TScope>> GetTrigger(IContext<Entity<TScope>> context)
			=> context.CreateCollector(ScopeMatcher<TScope>.AllOf(ID, Disabled).AddedOrRemoved());

		private static IMatcher<Entity<TScope>> ID => ScopeMatcher<TScope>.Get<ID>();

		private static IMatcher<Entity<TScope>> Disabled => ScopeMatcher<TScope>.Get<Disabled>();

		protected override bool Filter(Entity<TScope> entity) => true;

		protected override void Execute(List<Entity<TScope>> entities)
		{
			foreach (var entity in entities)
				DisableAllDependant(entity);
		}

		private void DisableAllDependant<TScope1>(Entity<TScope1> entity)
			where TScope1 : IScope
		{
			DisableDependant<TScope1, GameScope>(entity);
		}

		private void DisableDependant<TScope1, TScope2>(Entity<TScope1> parent)
			where TScope1 : IScope
			where TScope2 : IScope
		{
			foreach (var e in ForeignID.GetIndex<TScope2>().GetEntities(parent.Get<ID>().Value))
			{
				DisableAllDependant(e);
				e.Is<Disabled>(parent.Is<Disabled>());
			}
		}
	}
}