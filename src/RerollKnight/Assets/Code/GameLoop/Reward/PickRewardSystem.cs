using System.Collections.Generic;
using Code.Component;
using Entitas;
using Entitas.Generic;
using static Entitas.Generic.ScopeMatcher<Code.GameScope>;

namespace Code
{
	public sealed class PickRewardSystem : ReactiveSystem<Entity<GameScope>>
	{
		private readonly Contexts _contexts;
		private readonly ChipsFactory _chipsFactory;

		public PickRewardSystem(Contexts contexts, ChipsFactory chipsFactory)
			: base(contexts.Get<GameScope>())
		{
			_contexts = contexts;
			_chipsFactory = chipsFactory;
		}

		protected override ICollector<Entity<GameScope>> GetTrigger(IContext<Entity<GameScope>> context)
			=> context.CreateCollector(AllOf(Get<Reward>(), Get<Clicked>()));

		private Entity<GameScope> CurrentActor => _contexts.Get<GameScope>().Unique.GetEntity<CurrentActor>();

		protected override bool Filter(Entity<GameScope> entity) => entity.Is<Clicked>();

		protected override void Execute(List<Entity<GameScope>> entities)
		{
			foreach (var e in entities)
			{
				var activeFace = CurrentActor.GetActiveFace();

				_chipsFactory.Create(e.Get<ChipConfig>().Value, CurrentActor, activeFace);
				e.Is<Destroyed>(true);
			}
		}
	}
}