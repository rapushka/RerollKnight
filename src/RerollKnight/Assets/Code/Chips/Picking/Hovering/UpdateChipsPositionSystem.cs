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
			_chips = contexts.GetGroup(AllOf(Get<Chip>(), Get<PositionListener>(), Get<Visible>()));
		}

		public void Execute()
		{
			foreach (var e in _chips)
			{
				var newY = e.Get<InitialPosition>().Value.y + OffsetY(e);
				var position = e.Get<Position>().Value;

				if (!newY.ApproximatelyEquals(position.y))
					e.Replace<DestinationPosition, Vector3>(position.Set(y: newY));
			}
		}

		private float OffsetY(Entity<GameScope> entity)
			=> entity.Is<PickedChip>()          ? _layoutService.PickedChipOffset.y
				: !entity.Is<AvailableToPick>() ? _layoutService.UnavailableChipOffset.y
				                                  : 0f;
	}
}