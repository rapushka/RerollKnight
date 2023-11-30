using System.Collections.Generic;
using Code.Component;
using Entitas;
using Entitas.Generic;
using UnityEngine;
using static Entitas.Generic.ScopeMatcher<Code.GameScope>;

namespace Code
{
	public sealed class UpdateChipsPositionSystem : ReactiveSystem<Entity<GameScope>>
	{
		private readonly ILayoutService _layoutService;

		public UpdateChipsPositionSystem(Contexts contexts, ILayoutService layoutService)
			: base(contexts.Get<GameScope>())
		{
			_layoutService = layoutService;
		}

		protected override ICollector<Entity<GameScope>> GetTrigger(IContext<Entity<GameScope>> context)
			=> context.CreateCollector(AllOf(Get<PickedChip>(), Get<Position>()));

		protected override bool Filter(Entity<GameScope> entity) => true;

		protected override void Execute(List<Entity<GameScope>> entites)
		{
			foreach (var e in entites)
			{
				var initialPosition = e.Get<InitialPosition>().Value;
				e.Replace<DestinationPosition, Vector3>(initialPosition + Offset(e));
			}
		}

		private Vector3 Offset(Entity<GameScope> entity)
			=> entity.Is<PickedChip>()          ? _layoutService.PickedChipOffset
				: !entity.Is<AvailableToPick>() ? _layoutService.UnavailableChipOffset
				                                  : Vector3.zero;
	}
}