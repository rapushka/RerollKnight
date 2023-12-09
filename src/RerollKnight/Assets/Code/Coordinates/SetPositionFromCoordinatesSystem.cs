using Code.Component;
using Entitas;
using Entitas.Generic;
using UnityEngine;
using Zenject;
using static Entitas.Generic.ScopeMatcher<Code.GameScope>;

namespace Code
{
	public sealed class SetPositionFromCoordinatesSystem : IExecuteSystem
	{
		private readonly IViewConfig _layout;
		private readonly IGroup<Entity<GameScope>> _entities;

		[Inject]
		public SetPositionFromCoordinatesSystem(Contexts contexts, IViewConfig layout)
		{
			_layout = layout;
			_entities = contexts.GetGroup(AnyOf(Get<Component.Coordinates>(), Get<CoordinatesUnderField>()));
		}

		public void Execute()
		{
			foreach (var e in _entities)
			{
				var position = e.GetCoordinates().ToTopDown();

				if (e.Has<Component.Coordinates>())
					position += _layout.OverFieldOffset;

				e.Replace<Position, Vector3>(position);
			}
		}
	}
}