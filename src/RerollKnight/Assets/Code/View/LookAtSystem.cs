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
				var targetTransform = e.Get<LookAt>().Value;
				var position = e.Get<ViewTransform>().Value.position;
				var targetPosition = targetTransform.position;

				var direction = Vector3.Normalize(targetPosition - position);

				var rotation = Quaternion.LookRotation(direction);
				e.Replace<Rotation, Quaternion>(rotation);
			}
		}
	}
}