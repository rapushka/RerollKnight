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
		private readonly IViewConfig _viewConfig;
		private readonly IGroup<Entity<GameScope>> _chips;

		public UpdateChipsPositionSystem(Contexts contexts, IViewConfig viewConfig)
		{
			_viewConfig = viewConfig;
			_chips = contexts.GetGroup(AllOf(Get<Chip>(), Get<PositionListener>()));
		}

		public void Execute()
		{
			foreach (var e in _chips)
			{
				var newY = HeightFor(e);
				var position = e.Get<Position>().Value;

				if (!newY.ApproximatelyEquals(position.y))
					e.Replace<DestinationPosition, Vector3>(position.Set(y: newY));
			}
		}

		private float HeightFor(Entity<GameScope> entity)
			=> entity.Is<PickedChip>()          ? _viewConfig.Chips.PickedChipPositionY
				: !entity.Is<Visible>()         ? _viewConfig.Chips.InvisibleChipPositionY
				: !entity.Is<AvailableToPick>() ? _viewConfig.Chips.UnavailableChipPositionY
				                                  : _viewConfig.Chips.DefaultChipPositionY;
	}
}