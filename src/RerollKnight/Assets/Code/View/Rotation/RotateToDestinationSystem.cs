using Code.Component;
using Entitas;
using Entitas.Generic;
using UnityEngine;
using Zenject;
using static Entitas.Generic.ScopeMatcher<Code.GameScope>;

namespace Code
{
	public sealed class RotateToDestinationSystem : IExecuteSystem
	{
		private readonly IGroup<Entity<GameScope>> _entities;
		private readonly ITimeService _timeService;

		[Inject]
		public RotateToDestinationSystem(Contexts contexts, ITimeService timeService)
		{
			_entities = contexts.GetGroup(AllOf(Get<Rotation>(), Get<DestinationRotation>(), Get<RotationSpeed>()));
			_timeService = timeService;
		}

		public void Execute()
		{
			foreach (var e in _entities.GetEntities())
			{
				var current = e.Get<Rotation>().Value;
				var destination = e.Get<DestinationRotation>().Value;
				var speed = e.Get<RotationSpeed>().Value * _timeService.DeltaTime;

				if (current.AngleTo(destination) <= speed)
				{
					e.Replace<Rotation, Quaternion>(destination);
					e.Remove<DestinationRotation>();

					continue;
				}

				var nextRotation = Quaternion.Slerp(current, destination, speed);
				e.Replace<Rotation, Quaternion>(nextRotation);
			}
		}
	}
}