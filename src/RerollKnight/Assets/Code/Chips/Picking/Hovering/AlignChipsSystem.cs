using Code.Component;
using Entitas;
using Entitas.Generic;
using UnityEngine;
using static Entitas.Generic.ScopeMatcher<Code.GameScope>;
using PositionListener = Entitas.Generic.ListenerComponent<Code.GameScope, Code.Component.Position>;

namespace Code
{
	internal sealed class AlignChipsSystem : IExecuteSystem
	{
		private readonly IGroup<Entity<GameScope>> _chips;
		private readonly ILayoutService _layoutService;

		public AlignChipsSystem(Contexts contexts, ILayoutService layoutService)
		{
			_chips = contexts.GetGroup(AllOf(Get<Chip>(), Get<PositionListener>(), Get<Visible>()));
			_layoutService = layoutService;
		}

		private float Width => _layoutService.ChipsPanelWidth;

		public void Execute()
		{
			var positionsRange = CalculateChipsPanel();

			var positionStep = positionsRange.Delta / (_chips.count + 1);
			var currentPosition = positionsRange.Min;

			foreach (var e in _chips)
			{
				currentPosition += positionStep;
				var chipPosition = e.Get<Position>().Value;

				if (!chipPosition.x.ApproximatelyEquals(currentPosition))
					e.Replace<DestinationPosition, Vector3>(chipPosition.Set(x: currentPosition));
			}
		}

		private RangeFloat CalculateChipsPanel()
			=> RangeFloat.FromCenterAndRadius(0, Width);
	}
}