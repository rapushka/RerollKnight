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
				var newX = HorizontalPositionFor(e);
				var position = e.Get<Position>().Value;

				if (!newX.ApproximatelyEquals(position.x))
					e.Replace<DestinationPosition, Vector3>(position.Set(x: newX));
			}
		}

		private float HorizontalPositionFor(Entity<GameScope> entity)
			=> entity.Is<PickedChip>()          ? _viewConfig.Chips.PickedOffset
				: !entity.Is<Visible>()         ? _viewConfig.Chips.InvisibleOffset
				: !entity.Is<AvailableToPick>() ? _viewConfig.Chips.UnavailableOffset
				                                  : _viewConfig.Chips.DefaultOffset;
	}
}