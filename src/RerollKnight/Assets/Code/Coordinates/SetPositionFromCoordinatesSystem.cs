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
			_entities = contexts.GetGroup(Get<Component.Coordinates>());
		}

		public void Execute()
		{
			foreach (var e in _entities.Where((e) => !e.Is<Detached>()))
			{
				var coordinates = e.Get<Component.Coordinates>().Value;
				var position = coordinates.ToTopDown();

				if (coordinates.OnLayer is Coordinates.Layer.Default)
					position += _layout.OverFieldOffset;

				e.Replace<Position, Vector3>(position);
			}
		}
	}
}