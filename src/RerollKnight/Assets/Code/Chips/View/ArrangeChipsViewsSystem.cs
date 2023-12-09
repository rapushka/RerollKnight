using System.Collections.Generic;
using Code.Component;
using Entitas;
using Entitas.Generic;
using UnityEngine;
using static Entitas.Generic.ScopeMatcher<Code.GameScope>;
using PositionListener = Entitas.Generic.ListenerComponent<Code.GameScope, Code.Component.Position>;

namespace Code
{
	public sealed class ArrangeChipsViewsSystem : ReactiveSystem<Entity<GameScope>>
	{
		private readonly ILayoutService _layoutService;

		private int _counter;

		public ArrangeChipsViewsSystem(Contexts contexts, ILayoutService layoutService)
			: base(contexts.Get<GameScope>())
			=> _layoutService = layoutService;

		protected override ICollector<Entity<GameScope>> GetTrigger(IContext<Entity<GameScope>> context)
			=> context.CreateCollector(AllOf(Get<Chip>(), Get<PositionListener>()));

		protected override bool Filter(Entity<GameScope> entity) => entity.Is<Chip>();

		protected override void Execute(List<Entity<GameScope>> chips)
		{
			foreach (var chip in chips)
			{
				chip.Replace<Position, Vector3>(_layoutService.ChipsPositionStep * _counter);
				// chip.Add<InitialPosition, Vector3>(chip.Get<Position>().Value);

				_counter++;
			}
		}
	}
}