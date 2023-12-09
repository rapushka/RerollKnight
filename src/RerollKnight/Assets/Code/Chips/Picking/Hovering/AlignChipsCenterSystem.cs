using Code.Component;
using Entitas;
using Entitas.Generic;
using UnityEngine;
using static Entitas.Generic.ScopeMatcher<Code.GameScope>;
using PositionListener = Entitas.Generic.ListenerComponent<Code.GameScope, Code.Component.Position>;

namespace Code
{
	internal sealed class AlignChipsCenterSystem : IExecuteSystem
	{
		private readonly IGroup<Entity<GameScope>> _chips;
		private readonly ILayoutService _layoutService;

		public AlignChipsCenterSystem(Contexts contexts, ILayoutService layoutService)
		{
			_chips = contexts.GetGroup(AllOf(Get<Chip>(), Get<PositionListener>(), Get<Visible>()));
			_layoutService = layoutService;
		}

		private float Width => (_chips.count - 1) * _layoutService.MaxDistanceBetweenChips;

		public void Execute()
		{
			var range = RangeFloat.FromCenterAndWidth(0, Width);
			var positionStep = _layoutService.MaxDistanceBetweenChips;
			var currentPosition = range.Min;

			foreach (var e in _chips)
			{
				var chipPosition = e.Get<Position>().Value;

				if (!chipPosition.x.ApproximatelyEquals(currentPosition))
					e.Replace<DestinationPosition, Vector3>(chipPosition.Set(x: currentPosition));

				currentPosition += positionStep;
			}
		}
	}
}