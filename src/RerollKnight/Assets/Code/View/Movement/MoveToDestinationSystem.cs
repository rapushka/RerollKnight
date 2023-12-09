using Code.Component;
using Entitas;
using Entitas.Generic;
using UnityEngine;
using Zenject;
using static Entitas.Generic.ScopeMatcher<Code.GameScope>;

namespace Code
{
	public sealed class MoveToDestinationSystem : IExecuteSystem
	{
		private readonly IGroup<Entity<GameScope>> _entities;
		private readonly ITimeService _timeService;

		[Inject]
		public MoveToDestinationSystem(Contexts contexts, ITimeService timeService)
		{
			_entities = contexts.GetGroup(AllOf(Get<Position>(), Get<DestinationPosition>(), Get<MovingSpeed>()));
			_timeService = timeService;
		}

		public void Execute()
		{
			foreach (var e in _entities.GetEntities())
			{
				var position = e.Get<Position>().Value;
				var destination = e.Get<DestinationPosition>().Value;
				var speed = e.Get<MovingSpeed>().Value;

				var direction = (destination - position).normalized;
				var distance = position.DistanceTo(destination);
				var moveDistance = speed * _timeService.DeltaTime;

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