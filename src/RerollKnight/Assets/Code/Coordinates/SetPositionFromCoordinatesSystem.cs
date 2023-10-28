using Entitas;
using Zenject;
using static GameMatcher;

namespace Code
{
	public sealed class SetPositionFromCoordinatesSystem : IExecuteSystem
	{
		private readonly ILayoutService _layout;
		private readonly IGroup<GameEntity> _entities;

		[Inject]
		public SetPositionFromCoordinatesSystem(Contexts contexts, ILayoutService layout)
		{
			_layout = layout;
			_entities = contexts.game.GetGroup(AnyOf(GameMatcher.Coordinates, CoordinatesUnderField));
		}

		public void Execute()
		{
			foreach (var e in _entities)
			{
				var position = e.hasCoordinates
					? e.coordinates.Value.ToTopDown() + _layout.OverFieldOffset
					: e.coordinatesUnderField.Value.ToTopDown();

				e.ReplacePosition(position);
			}
		}
	}
}