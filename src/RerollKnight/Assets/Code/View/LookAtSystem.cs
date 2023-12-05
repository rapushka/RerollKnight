using Code.Component;
using Entitas;
using Entitas.Generic;
using UnityEngine;
using static Entitas.Generic.ScopeMatcher<Code.GameScope>;

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
				var targetRotation = target.Get<Rotation>().Value;

				// Transform.LookAt
				// (
				// 	worldPosition: position + targetRotation * Vector3.back,
				// 	worldUp: targetRotation * Vector3.up
				// );

				var forwardDirection = targetPosition - position;
				var rotation = Quaternion.LookRotation(forwardDirection, targetRotation * Vector3.up);

				e.Replace<Rotation, Quaternion>(rotation);
			}
		}
	}
}