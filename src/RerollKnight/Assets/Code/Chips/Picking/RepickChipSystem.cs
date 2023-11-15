using System.Collections.Generic;
using Code.Component;
using Entitas;
using Entitas.Generic;
using UnityEngine;
using Zenject;
using static Entitas.Generic.ScopeMatcher<Code.GameScope>;

namespace Code
{
	public sealed class RepickChipSystem : ReactiveSystem<Entity<GameScope>>
	{
		private readonly Contexts _contexts;
		private readonly IStateChangeBus _stateChangeBus;

		[Inject]
		public RepickChipSystem(Contexts contexts, IStateChangeBus stateChangeBus)
			: base(contexts.Get<GameScope>())
		{
			_contexts = contexts;
			_stateChangeBus = stateChangeBus;
		}

		private bool HasPickedChip => _contexts.Get<GameScope>().Unique.Has<PickedChip>();

		protected override ICollector<Entity<GameScope>> GetTrigger(IContext<Entity<GameScope>> context)
			=> context.CreateCollector(AllOf(Get<Clicked>(), Get<Chip>()).NoneOf(Get<PickedChip>()));

		protected override bool Filter(Entity<GameScope> entity) => entity.Is<Clicked>();

		protected override void Execute(List<Entity<GameScope>> entites)
		{
			foreach (var e in entites)
			{
				_stateChangeBus.ToState<ObservingGameState>();
				// _entitiesManipulator.UnpickAll(immediately: true);
				// RequestEmitter.Instance.Send<MarkAllTargetsAvailableRequest>();
				e.Pick();
				e.Is<Clicked>(false);
				_stateChangeBus.ToState<ChipPickedGameState>();
			}
		}
	}
}