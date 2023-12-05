using System.Collections.Generic;
using Code.Component;
using Entitas;
using Entitas.Generic;
using static Entitas.Generic.ScopeMatcher<Code.GameScope>;

namespace Code
{
	public sealed class WorldSpaceUiLookAtCameraSystem : ReactiveSystem<Entity<GameScope>>
	{
		private readonly Contexts _contexts;

		public WorldSpaceUiLookAtCameraSystem(Contexts contexts)
			: base(contexts.Get<GameScope>())
			=> _contexts = contexts;

		private Entity<GameScope> Camera => _contexts.Get<GameScope>().Unique.GetEntity<Camera>();

		protected override ICollector<Entity<GameScope>> GetTrigger(IContext<Entity<GameScope>> context)
			=> context.CreateCollector(Get<WorldSpaceUi>().AddedOrRemoved());

		protected override bool Filter(Entity<GameScope> entity) => true;

		protected override void Execute(List<Entity<GameScope>> entities)
		{
			foreach (var e in entities)
			{
				if (e.Is<WorldSpaceUi>())
					e.Add<LookAt, Entity<GameScope>>(Camera);
				else
					e.Remove<LookAt>();
			}
		}
	}
}