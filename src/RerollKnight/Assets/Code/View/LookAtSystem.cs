using Code.Component;
using Entitas;
using Entitas.Generic;
using UnityEngine;
using static Entitas.Generic.ScopeMatcher<Code.GameScope>;
using Camera = Code.Component.Camera;

namespace Code
{
	public sealed class LookAtSystem : IExecuteSystem
	{
		private readonly IGroup<Entity<GameScope>> _entities;

		public LookAtSystem(Contexts contexts)
		{
			_entities = contexts.GetGroup(Get<LookAt>());
		}

		public void Execute()
		{
			foreach (var e in _entities)
			{
				var target = e.Get<LookAt>().Value;

				var position = e.Get<Position>().Value;
				var targetPosition = target.Get<Position>().Value;

				var forwardDirection = targetPosition - position;
				var upwards = Vector3.up;

				if (e.Is<WorldSpaceUi>() && target.Is<Camera>())
				{
					var targetRotation = target.Get<Rotation>().Value;
					upwards = targetRotation * Vector3.up;
				}

				var rotation = Quaternion.LookRotation(forwardDirection, upwards);
				e.Replace<Rotation, Quaternion>(rotation);
			}
		}
	}
}