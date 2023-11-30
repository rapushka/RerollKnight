using System.Collections.Generic;
using Code.Component;
using Entitas;
using Entitas.Generic;
using static Entitas.Generic.ScopeMatcher<Code.GameScope>;

namespace Code
{
	public sealed class PickTargetSystem : ReactiveSystem<Entity<GameScope>>
	{
		public PickTargetSystem(Contexts contexts) : base(contexts.Get<GameScope>()) { }

		protected override ICollector<Entity<GameScope>> GetTrigger(IContext<Entity<GameScope>> context)
			=> context.CreateCollector(AllOf(Get<Clicked>(), Get<Target>(), Get<AvailableToPick>()));

		protected override bool Filter(Entity<GameScope> entity)
			=> entity.Is<Clicked>() && entity.Is<AvailableToPick>();

		protected override void Execute(List<Entity<GameScope>> entites)
		{
			foreach (var e in entites)
				e.Pick();
		}
	}
}