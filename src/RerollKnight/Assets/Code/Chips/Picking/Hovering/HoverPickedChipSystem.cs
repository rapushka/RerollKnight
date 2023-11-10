using System.Collections.Generic;
using Code.Component;
using Entitas;
using Entitas.Generic;
using UnityEngine;
using static Entitas.Generic.ScopeMatcher<Code.GameScope>;

namespace Code
{
	public sealed class HoverPickedChipSystem : ReactiveSystem<Entity<GameScope>>
	{
		private readonly ILayoutService _layoutService;

		public HoverPickedChipSystem(Contexts contexts, ILayoutService layoutService)
			: base(contexts.Get<GameScope>())
		{
			_layoutService = layoutService;
		}

		protected override ICollector<Entity<GameScope>> GetTrigger(IContext<Entity<GameScope>> context)
			=> context.CreateCollector(AllOf(Get<PickedChip>(), Get<Position>()));

		protected override bool Filter(Entity<GameScope> entity) => entity.Is<PickedChip>();

		protected override void Execute(List<Entity<GameScope>> entites)
		{
			foreach (var e in entites)
			{
				var initialPosition = e.Get<InitialPosition>().Value;
				e.Replace<DestinationPosition, Vector3>(initialPosition + _layoutService.PickingChipOffset);
			}
		}
	}
}