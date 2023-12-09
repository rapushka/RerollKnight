using Code.Component;
using Entitas;
using Entitas.Generic;
using UnityEngine;
using static Entitas.Generic.ScopeMatcher<Code.GameScope>;
using PositionListener = Entitas.Generic.ListenerComponent<Code.GameScope, Code.Component.Position>;

namespace Code
{
	public sealed class AlignChipsSystem : IExecuteSystem
	{
		private readonly IGroup<Entity<GameScope>> _chips;
		private readonly ILayoutService _layoutService;
		private readonly IHoldersProvider _holdersProvider;

		public AlignChipsSystem(Contexts contexts, ILayoutService layoutService, IHoldersProvider holdersProvider)
		{
			_chips = contexts.GetGroup(AllOf(Get<Chip>(), Get<PositionListener>(), Get<Visible>()));
			_holdersProvider = holdersProvider;
			_layoutService = layoutService;
		}

		private float Width => _layoutService.ChipsPanelWidth;

		private float Center => _holdersProvider.ChipsHolder.position.x;

		public void Execute()
		{
			var positionsRange = CalculateChipsPanel();

			var positionStep = positionsRange.Delta / (_chips.count + 1);
			var currentPosition = positionsRange.Min;

			foreach (var e in _chips)
			{
				var newPositionX = currentPosition;
				var chipPosition = e.Get<Position>().Value;

				if (!newPositionX.ApproximatelyEquals(chipPosition.x))
					e.Replace<DestinationPosition, Vector3>(chipPosition.Set(x: newPositionX));

				currentPosition += positionStep;
			}
		}

		private RangeFloat CalculateChipsPanel()
			=> RangeFloat.FromCenterAndRadius(Center, Width);
	}
}