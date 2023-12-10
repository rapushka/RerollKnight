using Code.Component;
using Entitas;
using Entitas.Generic;
using UnityEngine;
using static Entitas.Generic.ScopeMatcher<Code.GameScope>;

namespace Code
{
	public class RandomRotationSystem : IExecuteSystem
	{
		private readonly IGroup<Entity<GameScope>> _group;
		private readonly RandomService _random;
		private readonly ITimeService _time;

		public RandomRotationSystem(Contexts contexts, RandomService random, ITimeService time)
		{
			_group = contexts.GetGroup(AllOf(Get<Rotation>(), Get<RotationSpeed>()));
			_random = random;
			_time = time;
		}

		private Quaternion RandomRotation
			=> _random.Rotation();

		public void Execute()
		{
			foreach (var e in _group.GetEntities())
			{
				var rotation = e.Get<Rotation>().Value;
				var rotationSpeed = e.Get<RotationSpeed>().Value;
				rotation = Quaternion.RotateTowards(rotation, RandomRotation, _time.DeltaTime * rotationSpeed);
				e.Replace<Rotation, Quaternion>(rotation);
			}
		}
	}
}