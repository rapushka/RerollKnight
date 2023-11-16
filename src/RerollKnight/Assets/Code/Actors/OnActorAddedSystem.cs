using System.Collections.Generic;
using Code.Component;
using Entitas;
using Entitas.Generic;
using static Entitas.Generic.ScopeMatcher<Code.GameScope>;

namespace Code
{
	public sealed class OnActorAddedSystem : ReactiveSystem<Entity<GameScope>>
	{
		private readonly TurnsQueue _turnsQueue;

		public OnActorAddedSystem(Contexts contexts, TurnsQueue turnsQueue)
			: base(contexts.Get<GameScope>())
		{
			_turnsQueue = turnsQueue;
		}

		protected override ICollector<Entity<GameScope>> GetTrigger(IContext<Entity<GameScope>> context)
			=> context.CreateCollector(AnyOf(Get<Player>(), Get<Enemy>()).Added());

		protected override bool Filter(Entity<GameScope> entity) => entity.Is<Player>() || entity.Is<Enemy>();

		protected override void Execute(List<Entity<GameScope>> entites)
		{
			foreach (var e in entites)
			{
				e.Is<Actor>(true);
				_turnsQueue.OnActorAdded(e);
			}
		}
	}
}