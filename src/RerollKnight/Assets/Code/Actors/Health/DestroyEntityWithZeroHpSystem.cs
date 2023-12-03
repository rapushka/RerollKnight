using System.Collections.Generic;
using System.Linq;
using Code.Component;
using Entitas;
using Entitas.Generic;
using static Entitas.Generic.ScopeMatcher<Code.GameScope>;

namespace Code
{
	public sealed class DestroyEntityWithZeroHpSystem : ReactiveSystem<Entity<GameScope>>
	{
		public DestroyEntityWithZeroHpSystem(Contexts contexts) : base(contexts.Get<GameScope>()) { }

		protected override ICollector<Entity<GameScope>> GetTrigger(IContext<Entity<GameScope>> context)
			=> context.CreateCollector(Get<Health>());

		protected override bool Filter(Entity<GameScope> entity) => entity.Has<Health>();

		protected override void Execute(List<Entity<GameScope>> entities)
		{
			foreach (var entity in entities.Where(WithZeroHp))
				entity.Is<Destroyed>(true);
		}

		private bool WithZeroHp(Entity<GameScope> entity) => entity.Get<Health>().Value <= 0;
	}
}