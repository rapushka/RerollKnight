using System.Collections.Generic;
using Code.Component;
using Entitas;
using Entitas.Generic;
using static Entitas.Generic.ScopeMatcher<Code.GameScope>;

namespace Code
{
	public sealed class CollectActorsSystem : ReactiveSystem<Entity<GameScope>>
	{
		private readonly TurnsQueue _turnsQueue;
		private readonly IGroup<Entity<GameScope>> _entities;

		public CollectActorsSystem(Contexts contexts, TurnsQueue turnsQueue)
			: base(contexts.Get<GameScope>())
		{
			_turnsQueue = turnsQueue;
		}

		protected override ICollector<Entity<GameScope>> GetTrigger(IContext<Entity<GameScope>> context)
			=> context.CreateCollector(Get<Actor>());

		protected override bool Filter(Entity<GameScope> entity) => entity.Is<Actor>();

		protected override void Execute(List<Entity<GameScope>> entities)
		{
			foreach (var e in entities)
				_turnsQueue.OnActorAdded(e);
		}
	}
}