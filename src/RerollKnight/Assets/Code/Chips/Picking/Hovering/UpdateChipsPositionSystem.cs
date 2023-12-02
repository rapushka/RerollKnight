using Code.Component;
using Entitas;
using Entitas.Generic;
using UnityEngine;
using static Entitas.Generic.ScopeMatcher<Code.GameScope>;
using PositionListener = Entitas.Generic.ListenerComponent<Code.GameScope, Code.Component.Position>;

namespace Code
{
	public sealed class UpdateChipsPositionSystem : IExecuteSystem
	{
		private readonly ILayoutService _layoutService;
		private readonly IGroup<Entity<GameScope>> _chips;

		public UpdateChipsPositionSystem(Contexts contexts, ILayoutService layoutService)
		{
			_layoutService = layoutService;
			_chips = contexts.GetGroup(AllOf(Get<Chip>(), Get<PositionListener>()));
		}

		public void Execute()
		{
			foreach (var e in _chips)
			{
				var newPosition = e.Get<InitialPosition>().Value + Offset(e);

				if (newPosition != e.Get<Position>().Value)
					e.Replace<DestinationPosition, Vector3>(newPosition);
			}
		}

		private Vector3 Offset(Entity<GameScope> entity)
			=> entity.Is<PickedChip>()          ? _layoutService.PickedChipOffset
				: !entity.Is<AvailableToPick>() ? _layoutService.UnavailableChipOffset
				                                  : Vector3.zero;
	}
}