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
		private readonly IHoldersProvider _holders;

		public AlignChipsCenterSystem(Contexts contexts, IViewConfig viewConfig, IHoldersProvider holders)
		{
			_chips = contexts.GetGroup(AllOf(Get<Chip>(), Get<PositionListener>(), Get<Visible>()));
			_viewConfig = viewConfig;
			_holders = holders;
		}

		// private float Width   => (_chips.count - 1) * _viewConfig.Chips.MaxHorizontalSpacing;
		private float Spacing => _viewConfig.Chips.MaxHorizontalSpacing;

		public void Execute()
		{
			// var range = RangeFloat.FromCenterAndWidth(0, Width);
			var currentPositionY = 0f;

			foreach (var e in _chips)
			{
				var chipPosition = e.Get<Position>().Value;

				if (!chipPosition.y.ApproximatelyEquals(currentPositionY))
					e.Replace<DestinationPosition, Vector3>(chipPosition.Set(y: currentPositionY));

				currentPositionY += Spacing;
			}
		}
	}
}