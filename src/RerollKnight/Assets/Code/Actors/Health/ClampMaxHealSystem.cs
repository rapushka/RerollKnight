using System.Collections.Generic;
using Code.Component;
using Entitas;
using Entitas.Generic;
using static Entitas.Generic.ScopeMatcher<Code.GameScope>;

namespace Code
{
	public sealed class ClampMaxHealSystem : ReactiveSystem<Entity<GameScope>>
	{
		public ClampMaxHealSystem(Contexts contexts) : base(contexts.Get<GameScope>()) { }

		protected override ICollector<Entity<GameScope>> GetTrigger(IContext<Entity<GameScope>> context)
			=> context.CreateCollector(Get<Health>());

		protected override bool Filter(Entity<GameScope> entity) => entity.Has<Health>() && entity.Has<MaxHealth>();

		protected override void Execute(List<Entity<GameScope>> entities)
		{
			foreach (var entity in entities)
			{
				var health = entity.Get<Health>().Value;
				var maxHealth = entity.Get<MaxHealth>().Value;

				entity.Replace<Health, int>(health.Clamp(max: maxHealth));
			}
		}
	}
}