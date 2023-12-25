using Code.Component;
using Entitas;
using Entitas.Generic;
using UnityEngine;
using static Entitas.Generic.ScopeMatcher<Code.GameScope>;

namespace Code
{
	public sealed class TurnCasterToTargetSystem : IInitializeSystem
	{
		private readonly Contexts _contexts;
		private readonly IGroup<Entity<GameScope>> _targets;

		public TurnCasterToTargetSystem(Contexts contexts)
		{
			_contexts = contexts;

			_targets = contexts.GetGroup(AllOf(Get<PickedTarget>()));
		}

		private Entity<GameScope> CurrentActor => _contexts.Get<GameScope>().Unique.GetEntity<CurrentActor>();

		public void Initialize()
		{
			foreach (var target in _targets.GetEntities())
			{
				var casterCoordinates = CurrentActor.GetCoordinates(Coordinates.Layer.Default);
				var targetCoordinates = target.GetCoordinates(Coordinates.Layer.Default);

				var direction = (targetCoordinates - casterCoordinates).ToTopDown();

				var rotationAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
				var rotation = Quaternion.Euler(0f, rotationAngle, 0f);

				CurrentActor.Replace<Rotation, Quaternion>(rotation);
			}
		}
	}
}