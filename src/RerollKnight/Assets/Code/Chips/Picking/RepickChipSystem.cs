using System.Collections.Generic;
using Code.Component;
using Entitas;
using Entitas.Generic;
using static Entitas.Generic.ScopeMatcher<Code.GameScope>;

namespace Code
{
	public sealed class RepickChipSystem : ReactiveSystem<Entity<GameScope>>
	{
		private readonly IEntitiesManipulatorService _entitiesManipulator;
		private readonly Contexts _contexts;

		public RepickChipSystem(Contexts contexts, IEntitiesManipulatorService entitiesManipulator)
			: base(contexts.Get<GameScope>())
		{
			_entitiesManipulator = entitiesManipulator;
			_contexts = contexts;
		}

		private bool HasPickedChip => _contexts.Get<GameScope>().Unique.Has<PickedChip>();

		protected override ICollector<Entity<GameScope>> GetTrigger(IContext<Entity<GameScope>> context)
			=> context.CreateCollector(AllOf(Get<Clicked>(), Get<Chip>()).NoneOf(Get<PickedChip>()));

		protected override bool Filter(Entity<GameScope> entity) => HasPickedChip;

		protected override void Execute(List<Entity<GameScope>> entites)
		{
			foreach (var e in entites)
			{
				_entitiesManipulator.UnpickAll(immediately: true);
				RequestEmitter.Instance.Send<MarkAllTargetsAvailableRequest>();
				e.Pick();
				e.Is<Clicked>(false);
			}
		}
	}
}