using System.Collections.Generic;
using Code.Component;
using Entitas;
using Entitas.Generic;
using static Entitas.Generic.ScopeMatcher<Code.GameScope>;

namespace Code
{
	public sealed class MarkActorsSystem : ReactiveSystem<Entity<GameScope>>
	{
		public MarkActorsSystem(Contexts contexts) : base(contexts.Get<GameScope>()) { }

		protected override ICollector<Entity<GameScope>> GetTrigger(IContext<Entity<GameScope>> context)
			=> context.CreateCollector(AnyOf(Get<Player>(), Get<Enemy>()).AddedOrRemoved());

		protected override bool Filter(Entity<GameScope> entity) => true;

		protected override void Execute(List<Entity<GameScope>> entites)
		{
			foreach (var e in entites)
				e.Is<Actor>(e.Is<Player>() || e.Is<Enemy>());
		}
	}
}