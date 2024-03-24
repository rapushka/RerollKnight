using Code.Component;
using Entitas;
using Entitas.Generic;
using UnityEngine;
using static Entitas.Generic.ScopeMatcher<Code.GameScope>;

namespace Code
{
	public class RandomRotationSystem : IExecuteSystem
	{
		private readonly IGroup<Entity<GameScope>> _entities;
		private readonly RandomService _random;
		private readonly ITimeService _time;

		public RandomRotationSystem(Contexts contexts, RandomService random, ITimeService time)
		{
			_entities = contexts.GetGroup(Get<RandomlyRotating>());
			_random = random;
			_time = time;
		}

		private Quaternion RandomRotation => _random.Rotation();

		public void Execute()
		{
			foreach (var e in _entities)
			{
				var rotation = e.GetOrDefault<Rotation>()?.Value ?? Quaternion.identity;
				var rotationSpeed = e.Get<RotationSpeed>().Value;

				rotation *= Quaternion.Euler(RandomRotation.eulerAngles * rotationSpeed * _time.DeltaTime);
				e.Replace<Rotation, Quaternion>(rotation);
			}
		}
	}
}