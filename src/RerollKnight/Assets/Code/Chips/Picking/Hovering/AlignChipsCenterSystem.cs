using Code.Component;
using Entitas;
using Entitas.Generic;
using UnityEngine;
using static Entitas.Generic.ScopeMatcher<Code.GameScope>;
using PositionListener = Entitas.Generic.ListenerComponent<Code.GameScope, Code.Component.Position>;

namespace Code
{
	public sealed class AlignChipsCenterSystem : IExecuteSystem
	{
		private readonly IGroup<Entity<GameScope>> _chips;
		private readonly IViewConfig _viewConfig;

		public AlignChipsCenterSystem(Contexts contexts, IViewConfig viewConfig)
		{
			_chips = contexts.GetGroup(AllOf(Get<Chip>(), Get<PositionListener>(), Get<Visible>()));
			_viewConfig = viewConfig;
		}

		private float Width => (_chips.count - 1) * _viewConfig.Chips.MaxDistanceBetweenChips;

		public void Execute()
		{
			var range = RangeFloat.FromCenterAndWidth(0, Width);
			var positionStep = _viewConfig.Chips.MaxDistanceBetweenChips;
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