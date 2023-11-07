using Entitas;
using Entitas.Generic;
using UnityEngine;
using Zenject;
using static Entitas.Generic.ScopeMatcher<Code.GameScope>;

namespace Code
{
	public sealed class SetPositionFromCoordinatesSystem : IExecuteSystem
	{
		private readonly ILayoutService _layout;
		private readonly IGroup<Entity<GameScope>> _entities;

		[Inject]
		public SetPositionFromCoordinatesSystem(Contexts contexts, ILayoutService layout)
		{
			_layout = layout;
			_entities = contexts.GetGroup(AnyOf(Get<CoordinatesComponent>(), Get<CoordinatesUnderField>()));
		}

		public void Execute()
		{
			foreach (var e in _entities)
			{
				var position = e.GetCoordinates().ToTopDown();

				if (e.Has<CoordinatesComponent>())
					position += _layout.OverFieldOffset;

				e.Replace<Position, Vector3>(position);
			}
		}
	}
}