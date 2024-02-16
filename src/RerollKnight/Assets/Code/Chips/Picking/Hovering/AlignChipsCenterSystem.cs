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

		private float Spacing => _viewConfig.Chips.VerticalSpacing;

		public void Execute()
		{
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