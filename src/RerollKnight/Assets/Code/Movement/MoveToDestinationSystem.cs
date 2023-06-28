using Entitas;
using UnityEngine;
using static GameMatcher;

namespace Code
{
	public sealed class MoveToDestinationSystem : IExecuteSystem
	{
		private readonly IGroup<GameEntity> _entities;

		public MoveToDestinationSystem(Contexts contexts)
			=> _entities = contexts.game.GetGroup(AllOf(Position, DestinationPosition, MovingSpeed));

		public void Execute()
		{
			foreach (var e in _entities.GetEntities())
			{
				var position = e.position.Value;
				var destination = e.destinationPosition.Value;
				var speed = e.movingSpeed.Value;

				var direction = (destination - position).normalized;
				// TODO: Math service
				var distance = Vector3.Distance(position, destination);
				// TODO: Time service
				var moveDistance = speed * Time.deltaTime;

				if (distance <= moveDistance)
				{
					e.ReplacePosition(destination);
					e.RemoveDestinationPosition();
					continue;
				}

				e.ReplacePosition(position + direction * moveDistance);
			}
		}
	}
}