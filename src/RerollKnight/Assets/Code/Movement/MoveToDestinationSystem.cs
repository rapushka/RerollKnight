using Entitas;
using Entitas.Generic;
using UnityEngine;
using static Entitas.Generic.ScopeMatcher<Code.GameScope>;

namespace Code
{
	public sealed class MoveToDestinationSystem : IExecuteSystem
	{
		private readonly IGroup<Entity<GameScope>> _entities;

		public MoveToDestinationSystem(Contexts contexts)
			=> _entities = contexts.GetGroup(AllOf(Get<Position>(), Get<DestinationPosition>(), Get<MovingSpeed>()));

		public void Execute()
		{
			foreach (var e in _entities.GetEntities())
			{
				var position = e.Get<Position>().Value;
				var destination = e.Get<DestinationPosition>().Value;
				var speed = e.Get<MovingSpeed>().Value;

				var direction = (destination - position).normalized;
				// TODO: Math service
				var distance = Vector3.Distance(position, destination);
				// TODO: Time service
				var moveDistance = speed * Time.deltaTime;

				if (distance <= moveDistance)
				{
					e.Replace<Position, Vector3>(destination);
					e.Remove<DestinationPosition>();
					continue;
				}

				e.Replace<Position, Vector3>(position + direction * moveDistance);
			}
		}
	}
}