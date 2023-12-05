using System.Collections.Generic;
using Code.Component;
using Entitas;
using Entitas.Generic;
using UnityEngine;
using static Entitas.Generic.ScopeMatcher<Code.GameScope>;

namespace Code
{
	public sealed class DestroyDependentEntitiesWithActorSystem : ReactiveSystem<Entity<GameScope>>
	{
		public DestroyDependentEntitiesWithActorSystem(Contexts contexts) : base(contexts.Get<GameScope>()) { }

		protected override ICollector<Entity<GameScope>> GetTrigger(IContext<Entity<GameScope>> context)
			=> context.CreateCollector(AllOf(Get<ID>(), Get<Destroyed>()));

		protected override bool Filter(Entity<GameScope> entity) => entity.Is<Destroyed>();

		protected override void Execute(List<Entity<GameScope>> entities)
		{
			foreach (var entity in entities)
				DestroyAllDependant(entity);
		}

		private void DestroyAllDependant<TScope>(Entity<TScope> entity)
			where TScope : IScope
		{
			DestroyDependant<TScope, GameScope>(entity);
			DestroyDependant<TScope, ChipsScope>(entity);
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